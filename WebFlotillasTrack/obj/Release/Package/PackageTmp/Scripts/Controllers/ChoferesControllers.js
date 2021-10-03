var ChoferesControllers = function () {
    //var url = 'https://localhost:44348/Api/Choferes/';
    var url = 'http://adangonzalez-001-site4.ctempurl.com/Api/Choferes/';



    const tblChoferes = $('#tblChoferes');
    let dtChoferes;

    const cboEmpresa = $('#cboEmpresa');
    const txtNombre = $('#txtNombre');
    const txtApeidoPaterno = $('#txtApeidoPaterno');
    const txtApeidoMaterno = $('#txtApeidoMaterno');
    const txtUsuario = $('#txtUsuario');
    const txtContrasena = $('#txtContrasena');

    const btnAgregar = $('#btnAgregar');


    const btnGuardarChoferes = $('#btnGuardarChoferes');

    var Inicializar = function () {
        console.log('hola soy controlador')
        fncIniciar();
        ObtenerChoferes();
        Acciones();
    }
    const fncIniciar = function () {
        (function init() {
            InitTablaChoferes();
            })();
        }

    const limpiarInputs = function(){
        txtNombre.val('');
        txtApeidoMaterno.val('');
        txtApeidoPaterno.val('');
        txtUsuario.val('');
        txtContrasena.val('');
    }
    const Acciones = function(){
        btnGuardarChoferes.click(function(){
            fncCrearEditarChoferes();
        });
        btnAgregar.click(function(){
            limpiarInputs();
        });
    }
    const ObtenerChoferes = function(){
        let endPoint = url + 'ObtenerChoferes';
        let objModel = {
            idEmpresa:$('#idEmpresa').val()
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                AddRows(tblChoferes,datos);
            }
        });
    }
    const getParametros = function(){
        let parametros = {
            id: txtUsuario.attr('data-id'),
            idEmpresa: cboEmpresa.val(),
            users: txtUsuario.val(),
            pass: txtContrasena.val(),
            nombre: txtNombre.val(),
            apeidoP: txtApeidoPaterno.val(),
            apeidoM: txtApeidoMaterno.val(),
        }

        return parametros;
    }
    const InitTablaChoferes = function(){
        dtChoferes = tblChoferes.DataTable({
            destroy: true,
            ordering: false,
            language: 'dtDicEsp',
            searching: true,
            paging: true,

            columns: [
                { title: 'id ', visible: false, data: 'id', width: '6%' },
                { title: 'Empresa', data: 'Empresa', width: '7%' },
                { title: 'users', data: 'users', width: '7%' },
                { title: 'pass', data: 'pass', width: '7%' },
                { title: 'nombre', data: 'nombre', width: '7%' },
                { title: 'apeidoP', data: 'apeidoP', width: '7%' },
                { title: 'apeidoM', data: 'apeidoM', width: '7%' },
                {
                    title: 'botones', width: '7%',
                    render: function (data, type, row) {
                        let botones = '';
                        botones += `<button class='btn btn-success modificar' data-id="${row.id}"><i class="fas fa-upload"></i></button>&nbsp`;
                        botones += `<button class='btn btn-danger eliminar' data-id="${row.id}"><i class="fas fa-trash"></i></button>`;
                        return botones;
                    }
                }
            ],
           
            initComplete: function (settings, json) {
                tblChoferes.on("click", ".eliminar", function () {
                    let strMensaje = "¿Desea eliminar el registro seleccionado?";

                    Swal.fire({
                        position: "center",
                        icon: "warning",
                        title: "¡Cuidado!",
                        width: '35%',
                        showCancelButton: true,
                        html: `<h3>${strMensaje}</h3>`,
                        confirmButtonText: "Confirmar",
                        confirmButtonColor: "#5cb85c",
                        cancelButtonText: "Cancelar",
                        cancelButtonColor: "#d9534f",
                        showCloseButton: true
                    }).then((result) => {
                        if (result.value) {
                            let parametros = { id: $(this).attr("data-id") };
                            fncEliminarChoferes(parametros);
                        }
                    });
                });

                tblChoferes.on("click", ".modificar", function (e) {
                    const rowData = dtChoferes.row($(this).closest("tr")).data();
                    $('#modalChoferes').modal('show');
                    console.log(rowData)
                    txtUsuario.attr('data-id', rowData.id)
                    txtUsuario.val(rowData.users);


                });
            }

        });
    }
    function AddRows(tbl, lst) {
        dt = tbl.DataTable();
        dt.clear().draw();
        dt.draw();
        dt.rows.add(lst).draw(false);
    }


    function fncCrearEditarChoferes() {
        let endPoint = url + 'CrearEditarChoferes';
        let objModel = getParametros();
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                if (datos.status == 1) {
                    $('#modalChoferes').modal('hide')
                    utilitis.Alert2Exitoso(datos.mensaje);
                    ObtenerChoferes();
                } else if (datos.status == 2) {
                    $('#modalChoferes').modal('hide')
                    utilitis.Alert2Exitoso(datos.mensaje);
                    ObtenerChoferes();
                } else {
                    utilitis.Alert2Error(datos.mensaje);
                }
            }
        });
    }
    function fncEliminarChoferes(parametros) {
        let endPoint = url + 'EliminarChoferes';
        let objModel = parametros;
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                if (datos.status == 1) {
                    utilitis.Alert2Exitoso(datos.mensaje);
                    ObtenerChoferes();
                } else {
                    utilitis.Alert2Error(datos.mensaje);
                }
            }
        });
    }









        return {
        Inicializar: Inicializar,
    }
};