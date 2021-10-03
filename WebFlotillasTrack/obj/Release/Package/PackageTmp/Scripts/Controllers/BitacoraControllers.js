var BitacoraControllers = function () {

    //var url = 'https://localhost:44348/Api/Bitacora/';
    //var urlLog = 'https://localhost:44348/Api/Login/';
    //var urlChof = 'https://localhost:44348/Api/Choferes/';

    var url = 'http://adangonzalez-001-site4.ctempurl.com/Api/Bitacora/';
    var urlLog = 'http://adangonzalez-001-site4.ctempurl.com/Api/Login/';
    var urlChof = 'http://adangonzalez-001-site4.ctempurl.com/Api/Choferes/';


    const tblBitacora = $('#tblBitacora');
    let dtBitacora;
    const btnGuardarModalArchivos = $('#btnGuardarModalArchivos');
    const cboEmpresa = $('#cboEmpresa');
    const nptEmpresaID = $('#nptEmpresaID');
    const cboUsuario = $('#cboUsuario');

    const calendarEl = document.getElementById('calendar');
    let calendar;
    const btnGuardar = $('#btnGuardar');
    const cboEstado = $('#cboEstado');
    var Inicializar = function () {
        console.log(nptEmpresaID.val())
        if (nptEmpresaID.val()!=null && nptEmpresaID.val()!='') {
            llenarComboUsuario();
        }
        console.log('hola')
        fncIniciar();
        llenarCombo();
        fncButtons();
        bitacoraCalendario();
        cboUsuario.change(function(){
            obtenerBitacoraEvents();
            obtenerBitacoraInformacion();
        });
    }

    const fncButtons = function(){
        cboEmpresa.change(function(){
            nptEmpresaID.val(cboEmpresa.val());
            console.log(nptEmpresaID.val());
              llenarComboUsuario();
        });
        btnGuardar.click(function(){
            EditarBitacora();
            
        })
    }
  
    const fncIniciar = function(){
        (function init() {
            InitBitacora();
        })();
    }
    const InitBitacora = function(){
        dtBitacora = tblBitacora.DataTable({
            destroy: true,
            ordering: false,
            language: 'dtDicEsp',
            searching: true,
            paging: true,

            columns: [
                { title: 'id ', visible: false, data: 'id', width: '6%' },
                { title: 'EstadoAccion ', data: 'EstadoAccion', width: '6%' },
                { title: 'fechaInicio ', data: 'fechaInicio', width: '6%' },
                { title: 'fechaFin ', data: 'fechaFin', width: '6%' },
                { title: 'longitud ', data: 'longitud', width: '6%' },
                { title: 'latitud ', data: 'latitud', width: '6%' },
                { title: 'nombreUbicacion ', data: 'nombreUbicacion', width: '6%' },
                {
                    title: 'botones', width: '7%',
                    render: function (data, type, row) {
                        let botones = '';
                        botones += `<button class='btn btn-success modificar' data-id="${row.id}"><i class="fas fa-upload"></i></button>&nbsp`;
                        // botones += `<button class='btn btn-danger eliminar' data-id="${row.id}"><i class="fas fa-trash"></i></button>`;
                        return botones;
                    }
                }
            ],
           
            initComplete: function (settings, json) {
                tblBitacora.on("click", ".eliminar", function () {
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

                tblBitacora.on("click", ".modificar", function (e) {
                    const rowData = dtBitacora.row($(this).closest("tr")).data();
                    $('#modalChoferes').modal('show');
                    btnGuardar.attr("data-id",rowData.id);

                });
            }

        });
    }
    function EditarBitacora() {
        let endPoint = urlChof + 'EditarBitacora';
        let objModel = {
            id:btnGuardar.attr("data-id"),
            idEstado:cboEstado.val()
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
                obtenerBitacoraInformacion();
                obtenerBitacoraEvents();
                $('#modalChoferes').modal('hide');
                if (datos != undefined) {
                console.log(datos)
            }
        });
    }
    function AddRows(tbl, lst) {
        dt = tbl.DataTable();
        dt.clear().draw();
        dt.draw();
        dt.rows.add(lst).draw(false);
    }

    const obtenerBitacoraInformacion = function(){
        function zero(n) {
            return (n>9 ? '' : '0') + n;
           }
           var date = new Date();
        let fechaActual = date.getFullYear() +"-"+zero(date.getMonth()+1) +"-"+zero(date.getDate()) 
        let endPoint = url + 'ObtenerBitacoraInformacion';
        let objModel = {
            fechaActual:fechaActual,
            idChofer:cboUsuario.val()
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                console.log(datos)
                AddRows(tblBitacora,datos);
            }
        });
    }

    const obtenerBitacoraEvents = function(){
        function zero(n) {
            return (n>9 ? '' : '0') + n;
           }
           var date = new Date();
        let fechaActual = date.getFullYear() +"-"+zero(date.getMonth()+1) +"-"+zero(date.getDate()) 
        let endPoint = url + 'ObtenerBitacoraEventos';
        let objModel = {
            fechaActual:fechaActual,
            idChofer:cboUsuario.val()
        };
        let Peticion = {
            Model: JSON.stringify(objModel),
            Formato: 2
        }
        objService.PostToken(endPoint, Peticion, function (result) {
            let datos = JSON.parse(result.Model);
            if (datos != undefined) {
                console.log(datos)
                bitacoraCalendario(datos,fechaActual);
            }
        });
    }

    const bitacoraCalendario = function(events,fechaActual){
        if (calendar != null) {
            calendar.destroy();
        }
        
             calendar = new FullCalendar.Calendar(calendarEl, {
            schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
            now: fechaActual,
              editable: true,
              aspectRatio: 1.8,
              scrollTime: '00:00',
              height: '320px',
              headerToolbar: {
                left: 'today prev,next',
                center: 'title',
                right: 'resourceTimelineDay'
              },
              initialView: 'resourceTimelineDay',
              views: {
                resourceTimelineThreeDays: {
                  type: 'resourceTimeline',
                }
              },
              resourceAreaWidth: '10%',
              resourceAreaColumns: [
                {
                  headerContent: 'ESTADOS',
                  field: 'title'
                },
              ],
              resources: [
                { id: '2', title: 'DRIVE', eventColor: 'green' },
                { id: '3', title: 'OFF', eventColor: 'black' },
                { id: '4', title: 'SB', eventColor: 'orange' },
                { id: '1', title: 'ON DUTY' , eventColor: 'yellow'},
              ],
              events: events
            });
        
            calendar.render();
          
    }


    const llenarCombo = function(){
        let endPoint = urlLog + 'ObtenerEmpresas';
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
                    let groupOption = `<option value="0">--Seleccione--</option>`;
                datos.forEach(y => {
                    groupOption += `<option value="${y.id}">${y.Empresa}</option>`;
                });
                cboEmpresa.append(groupOption);
            }
        });
    }
    const llenarComboUsuario = function(){
        cboUsuario.find('option').remove();

        let endPoint = urlChof + 'ObtenerChoferes';
        let objModel = {
            idEmpresa:nptEmpresaID.val()
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
                    groupOption += `<option value="${y.id}">${y.users}</option>`;
                });
                cboUsuario.append(groupOption);
            }
        });
    }

    return {
        Inicializar: Inicializar,
    }
};