console.log('utils.js loaded');

function downloadFile(fileName, base64Data, mimeType) {
    try {
        // Decode base64 to bytes
        const byteCharacters = atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: mimeType || 'application/octet-stream' });
        const url = URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        URL.revokeObjectURL(url);
    } catch (e) {
        console.error('downloadFile error', e);
    }
}

async function readFileText(inputId) {
    return new Promise((resolve, reject) => {
        const input = document.getElementById(inputId);
        if (!input || !input.files || input.files.length === 0) {
            resolve("");
            return;
        }
        const file = input.files[0];
        const reader = new FileReader();
        reader.onload = () => resolve(reader.result);
        reader.onerror = () => reject(reader.error);
        reader.readAsText(file);
    });
}

window.downloadFile = downloadFile;
window.readFileText = readFileText;
// Backward compatibility for existing PDF download calls
function descargarArchivo(nombreArchivo, contenidoBase64) {
    // If caller already passed a data URL, strip prefix
    const base64 = (typeof contenidoBase64 === 'string' && contenidoBase64.startsWith('data:'))
        ? contenidoBase64.substring(contenidoBase64.indexOf(',') + 1)
        : contenidoBase64;
    downloadFile(nombreArchivo, base64, 'application/pdf');
}
window.descargarArchivo = descargarArchivo;

function navigateTo(url) {
    window.location.href = url;
}
window.navigateTo = navigateTo;
window.descargarArchivo = descargarArchivo; 