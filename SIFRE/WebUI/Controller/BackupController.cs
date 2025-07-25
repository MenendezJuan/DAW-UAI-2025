using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interfaces.BLL;

namespace WebUI.Controller
{
    [ApiController]
    [Route("api/backup")]
    public class BackupController : ControllerBase
    {
        private readonly IBackupBLL _backupBLL;

        public BackupController(IBackupBLL backupBLL)
        {
            _backupBLL = backupBLL;
        }

        [HttpGet("download")]
        public IActionResult DownloadBackup()
        {
            string backupFolder = @"C:\Documents";
            Directory.CreateDirectory(backupFolder);

            _backupBLL.CreateBackup(backupFolder);

            var lastFile = Directory.GetFiles(backupFolder, "Backup_*.bak")
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.CreationTime)
                .FirstOrDefault();

            if (lastFile == null || !System.IO.File.Exists(lastFile.FullName))
                return NotFound("No se pudo generar el archivo de backup.");

            var downloadName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            var stream = new FileStream(lastFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(stream, "application/octet-stream", downloadName);
        }

        [HttpPost("restore")]
        public IActionResult RestoreBackup([FromForm] IFormFile file)
        {
            if (file == null)
                return BadRequest("No se recibió ningún archivo.");

            string tempFile = Path.Combine(Path.GetTempPath(), file.FileName);
            using (var fs = new FileStream(tempFile, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            _backupBLL.RestoreBackup(tempFile);

            return Ok();
        }
    }
}
