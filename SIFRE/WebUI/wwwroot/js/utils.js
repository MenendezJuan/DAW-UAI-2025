console.log('utils.js loaded');

function descargarArchivo(nombreArchivo, contenidoBase64) {
    const link = document.createElement('a');
    link.href = "data:application/pdf;base64," + contenidoBase64;
    link.download = nombreArchivo;
    document.body.appendChild(link);

    link.click();

    document.body.removeChild(link);
}

window.descargarArchivo = descargarArchivo; 