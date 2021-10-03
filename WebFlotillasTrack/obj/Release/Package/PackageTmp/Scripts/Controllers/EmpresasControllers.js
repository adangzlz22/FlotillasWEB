var EmpresasControllers = function () {

    //var url = 'https://localhost:44348/Api/Login/';

    var url = 'http://adangonzalez-001-site4.ctempurl.com/Api/Login/';




    const cboEmpresa = $('#cboEmpresa');
    const txtNombre = $('#txtNombre');
    const txtApeidoPaterno = $('#txtApeidoPaterno');
    const txtApeidoMaterno = $('#txtApeidoMaterno');
    const txtUsuario = $('#txtUsuario');
    const txtContrasena = $('#txtContrasena');
    const txtEmail = $('#txtEmail');
    const txtUsuariosmbTrack = $('#txtUsuariosmbTrack');
    const txtContrasenasmbTrack = $('#txtContrasenasmbTrack');
    
    const tblUsuarios = $('#tblUsuarios');
    const tblEmpresasModal = $('#tblEmpresasModal');
    let dtEmpresaModal;
    let dtEmpresas
    const btnGuardarModalArchivos = $('#btnGuardarModalArchivos');
    const btnAgregar = $('#btnAgregar');
    const btnBuscar = $('#btnBuscar');
    const btnCrearEditarModal = $('#btnCrearEditarModal');
    const btnModalAgregarEmpresa = $('#btnModalAgregarEmpresa');

    var Inicializar = function () {
        console.log('hola')

        fncIniciar();
        fncButtons();
        getListaUsuarios();
        llenarCombo();
    }
    const fncButtons = function () {
        btnBuscar.click(function () {
            getListaUsuarios();
        });
        btnAgregar.click(function () {
            LimpiarInputs();
        });
        btnGuardarModalArchivos.click(function () {
            GuardarEditar();
        });
        btnModalAgregarEmpresa.click(function () {
            console.log('hola')
            $('#txtNombreEmpresaModal').attr('data-id', 0)
        });
        btnCrearEditarModal.click(function(){
            GuardarEditarEmpresa();
        });
    }
    const fncIniciar = function () {
        (function init() {
            initblEmpresa();
            initblEmpresaModal();
            getListaUsuarios();
            getListaEmpresas();
        })();
    }
    const initblEmpresa = function () {
        dtEmpresas = tblUsuarios.DataTable({
            destroy: true,
            ordering: false,
            language: 'dtDicEsp',
            searching: true,
            paging: true,

            columns: [
                { title: 'id ', visible: false, data: 'id', width: '6%' },
                { title: 'Empresa', data: 'Empresa', width: '7%' },
                {
                    title: 'NombreCompleto', width: '7%',
                    render: function (data, type, row) {
                        let txt = '';
                        txt += `${row.nombre} ${row.apeidoPaterno} ${row.apeidoMaterno}`;
                        return txt;
                    }
                },
                { title: 'Users', data: 'users', width: '7%' },
                { title: 'Pass', data: 'pass', width: '7%' },
                { title: 'correo', data: 'correo', width: '7%' },
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
                tblUsuarios.on("click", ".eliminar", function () {
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
                            fncEliminarUsuario(parametros);
                        }
                    });
                });

                tblUsuarios.on("click", ".modificar", function (e) {
                    const rowData = dtEmpresas.row($(this).closest("tr")).data();
                    $('#modalCambiosCategorias').modal('show');
                    console.log(rowData)
                    txtUsuario.attr('data-id', rowData.id)
                    txtUsuario.val(rowData.users);
                    txtContrasena.val(rowData.pass);
                    txtEmail.val(rowData.correo);
                    txtNombre.val(rowData.nombre);
                    txtApeidoPaterno.val(rowData.apeidoPaterno);
                    txtApeidoMaterno.val(rowData.apeidoMaterno);

                });
            }


        });
    }
    const initblEmpresaModal = function () {
        dtEmpresaModal = tblEmpresasModal.DataTable({
            destroy: true,
            ordering: false,
            language: 'dtDicEsp',
            searching: true,
            paging: true,

            columns: [
                { title: 'id ', visible: false, data: 'id', width: '6%' },
                { title: 'Empresa', data: 'Empresa', width: '7%' },
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
                tblEmpresasModal.on("click", ".eliminar", function () {
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
                            fncEliminarEmpresas(parametros);
                        }
                    });
                });

                tblEmpresasModal.on("click", ".modificar", function (e) {
                    const rowData = dtEmpresaModal.row($(this).closest("tr")).data();
                    $('#modalAgregarEmpresa').modal('show');
                    console.log(rowData)
                    $('#txtNombreEmpresaModal').attr('data-id', rowData.id)
                    $('#txtNombreEmpresaModal').val(rowData.Empresa);


                });
            }

        });
    }
    var getListaUsuarios = function () {
        let endPoint = url + 'ObtenerUsuarioYEmpresa';
        let objModel = {
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                console.log(datos)
                AddRows(tblUsuarios, datos)
            }
        });
    }
    var getListaEmpresas = function () {
        let endPoint = url + 'ObtenerEmpresas';
        let objModel = {
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                console.log(datos)
                AddRows(tblEmpresasModal, datos)
            }
        });
    }
    function AddRows(tbl, lst) {
        dt = tbl.DataTable();
        dt.clear().draw();
        dt.draw();
        dt.rows.add(lst).draw(false);
    }
    function obtenerEmpresa() {
        let parametros = getParametros();
        let endPoint = url + 'ObtenerEmpresa';
        let objModel = {
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                console.log(datos)
                dtEmpresas.clear();
                dtEmpresas.rows.add(datos);
                dtEmpresas.draw();
            }
        });
    }
    function GuardarEditar() {
        let endPoint = url + 'CrearEditarUsuario';
        let objModel = getParametros();
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                if (datos.status == 1) {
                    $('#modalCambiosCategorias').modal('hide')
                    utilitis.Alert2Exitoso(datos.mensaje);
                    getListaUsuarios();
                } else if (datos.status == 2) {
                    $('#modalCambiosCategorias').modal('hide')
                    utilitis.Alert2Exitoso(datos.mensaje);
                    getListaUsuarios();
                } else {
                    utilitis.Alert2Error(datos.mensaje);
                }
            }
        });
    }
    function fncEliminarUsuario(parametros) {
        let endPoint = url + 'EliminarUsuario';
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
                    getListaUsuarios();
                } else {
                    utilitis.Alert2Error(datos.mensaje);
                }
            }
        });
    }
    function LimpiarInputs() {
        txtUsuario.attr('data-id', 0);
        txtUsuario.val('');
        txtContrasena.val('');
        txtEmail.val('');
        txtNombre.val('');
        txtApeidoPaterno.val('');
        txtApeidoMaterno.val('');
    }
    const getParametros = function () {
        let parametros = {
            id: txtUsuario.attr('data-id'),
            idEmpresa: cboEmpresa.val(),
            users: txtUsuario.val(),
            pass: txtContrasena.val(),
            correo: txtEmail.val(),
            nombre: txtNombre.val(),
            ApeidoP: txtApeidoPaterno.val(),
            ApeidoM: txtApeidoMaterno.val(),
            idNivel: 1,
            userSmbTrack:txtUsuariosmbTrack.val(),
            passSmbTrack:txtContrasenasmbTrack.val(),
        }

        return parametros;
    }
    const fncEliminarEmpresas = function(parametros){
        let endPoint = url + 'EliminarEmpresa';
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
                    getListaEmpresas();
                } else {
                    utilitis.Alert2Error(datos.mensaje);
                }
            }
        });
    }
    const GuardarEditarEmpresa = function(){
        let endPoint = url + 'CrearEditarEmpresa';
        let objModel = getParametrosEmpresa();
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                if (datos.status == 1) {
                    $('#modalAgregarEmpresa').modal('hide')
                    utilitis.Alert2Exitoso(datos.mensaje);
                    getListaEmpresas();
                    limpiarEmpresas();
                } else if (datos.status == 2) {
                    $('#modalAgregarEmpresa').modal('hide')
                    utilitis.Alert2Exitoso(datos.mensaje);
                    getListaEmpresas();
                    limpiarEmpresas();
                } else {
                    utilitis.Alert2Error(datos.mensaje);
                }
            }
        });
    }
    const limpiarEmpresas = function(){
        $('#txtNombreEmpresaModal').attr('data-id',0),
        $('#txtNombreEmpresaModal').val('')
    }
    const getParametrosEmpresa = function(){
        let parametros={
            id:$('#txtNombreEmpresaModal').attr('data-id'),
            Empresa:$('#txtNombreEmpresaModal').val()
        }
        return parametros;
    }
    const llenarCombo = function(){
        let endPoint = url + 'ObtenerEmpresas';
        let objModel = {
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                console.log(datos)
                    let groupOption = ``;
                datos.forEach(y => {
                    groupOption += `<option value="${y.id}">${y.Empresa}</option>`;
                });
                cboEmpresa.append(groupOption);
            }
        });
    }

    return {
        Inicializar: Inicializar,
    }
};