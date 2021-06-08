

var utilitis = function () {


    var Alert2Error = function (Mensaje) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: Mensaje
        })
    }
    var Alert2Exitoso = function(Mensaje){
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: Mensaje,
            showConfirmButton: false,
            timer: 1500
          })
    }

    return {
        Alert2Error: Alert2Error,
        Alert2Exitoso:Alert2Exitoso,
    }
}
///Se crea la instancia desde que se agrega el archivo para que este global
var utilitis = new utilitis();