var LoginControllers = function () {

    //var url = 'https://localhost:44348/Api/Login/';
    //var url2 = 'https://localhost:44348/Api/Choferes/';

    var vistas = 'http://adangonzalez-001-site4.ctempurl.com/Vistas/';

    var url = 'http://adangonzalez-001-site4.ctempurl.com/Api/Login/';
    var url2 = 'http://adangonzalez-001-site4.ctempurl.com/Api/Choferes/';


    const txtUser = $('#txtUser');
    const txtPass = $('#txtPass');
    const btnLogearse = $('#btnLogearse');
    const tblDatos = $('#tblDatos');
    let dtDatos;


    var Inicializar = function () {

        console.log('soy login ssscontrollers');
        fncButtons();
        fncIniciar();
        timer();
    }

    const fncButtons = function(){
        btnLogearse.click(function(){
            EjecutarSP();
        });
    }
  
    const fncIniciar = function(){
        (function init() {
        })();
    }



    var EjecutarSP = function () {
        let endPoint = url + 'Logearse';
        let objModel = {
            users: txtUser.val(),
            pass: txtPass.val()
        };
        let Peticion = {
            Model:JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos!=undefined) {
                $(location).attr('href', vistas +'Logearse?users='+datos.users+'&idNivel='+datos.idNivel+'&idEmpresa='+datos.idEmpresa);
            }
        });
    }


    const timer = function(){
        let contador = 0;
        setInterval(function () {
            (function () {
                contador++;
                console.log(contador)
                if (contador==600) {
                    contador=0;
                    EjecutarExtracciondeUbicaciones();
                }
            })();
        }, 1000);
    }


    const EjecutarExtracciondeUbicaciones = function(){
        function zero(n) {
            return (n>9 ? '' : '0') + n;
           }
           var date = new Date();
        let fechaInicio = date.getFullYear() +"-"+zero(date.getMonth()+1) +"-"+zero(date.getDate()) +" "+ zero(date.getHours()) + ":" + zero(date.getMinutes()-10) + ":" + zero(date.getSeconds());
        let fechaFin = date.getFullYear() +"-"+zero(date.getMonth()+1) +"-"+zero(date.getDate()) +" "+ zero(date.getHours()) + ":" + zero(date.getMinutes()) + ":" + zero(date.getSeconds());
     console.log(fechaInicio)
     console.log(fechaFin)
        let endPoint = url2 + 'EjecutarExtracciondeUbicaciones';
        let objModel = {
            fechaInicio:fechaInicio,
            fechaFin:fechaFin,
        };
        let Peticion = {
            Model:JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
           
        });
    }



    return {
        Inicializar: Inicializar,
    }
};