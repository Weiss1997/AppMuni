/*Seccion Para Bloqueo de input segun opciones*/
window.onload = OcultarGuardadoUsuario();
function OcultarGuardadoUsuario() {
    $("#PreguntaUsuario").prop("hidden", true);
}
$("#DiagnosticoEnfermedad").change(function () {
    if ($(this).val() === "false") {
        $("#DetalleDiagnosticoEnfermedad").prop("hidden", true);
        $("#CualDiagnostico").prop("hidden", true);
        $("#DetalleDiagnosticoEnfermedadValidacion").addClass("ocultar");
    } else {
        $("#DetalleDiagnosticoEnfermedad").prop("hidden", false);
        $("#CualDiagnostico").prop("hidden", false);
        $("#DetalleDiagnosticoEnfermedadValidacion").addClass("ocultar");

    }
});

$("#PersonaObraSocialCrear").change(function () {
    if ($(this).val() === "false") {
        $("#div-obrasocial-cual").prop("hidden", true);
    } else {
        $("#div-obrasocial-cual").prop("hidden", false);
    }
});

$("#CudExistente").change(function () {
    if ($(this).val() === "1") {
        $("#NumeroCUD").prop("hidden", false);
        $("#VencimientoCud").prop("hidden", false);
        $("#VencimientoCUDTitulo").prop("hidden", false);
        $("#NumeroCUDTitulo").prop("hidden", false);
        $("#NumeroCUDValidacion").addClass("ocultar");
        $("#VencimientoCudValidacion").addClass("ocultar");
    } else {
        $("#NumeroCUD").prop("hidden", true);
        $("#VencimientoCud").prop("hidden", true);
        $("#VencimientoCUDTitulo").prop("hidden", true);
        $("#NumeroCUDTitulo").prop("hidden", true);
        $("#NumeroCUDValidacion").addClass("ocultar");
        $("#VencimientoCudValidacion").addClass("ocultar");

    }
});
$("#InicioDiscapacidadNacimiento").change(function () {
    if ($(this).val() === "false") {
        $("#div-Fechainiciodiscapacidad").removeClass("ocultar");
    } else {
        $("#div-Fechainiciodiscapacidad").addClass("ocultar");
    }
});
$("#TratamientoMedico").change(function () {
    if ($(this).val() === "false") {
        $("#DetalleTratamientoMedico").prop("hidden", true);
        $("#cualTratamiento").prop("hidden", true);
        $("#DondeTratamiento").prop("hidden", true);
        $("#LugarTratamientoMedico").prop("hidden", true);
        $("#DetalleTratamientoMedicoValidacion").addClass("ocultar");
        $("#LugarTratamientoMedicoValidacion").addClass("ocultar");
    } else {
        $("#DetalleTratamientoMedico").prop("hidden", false);
        $("#LugarTratamientoMedico").prop("hidden", false);
        $("#cualTratamiento").prop("hidden", false);
        $("#DondeTratamiento").prop("hidden", false);
        $("#DetalleTratamientoMedicoValidacion").addClass("ocultar");
        $("#LugarTratamientoMedicoValidacion").addClass("ocultar");
    }
});
$("#CuentaConParienteAQuienRecurir").change(function () {
    if ($(this).val() === "false") {
        $("#AQueParienteRecurir").prop("hidden", true);
        $("#AQueParienteRecurirTitulo").prop("hidden", true);
        $("#AQueParienteRecurirValidacion").addClass("ocultar");

    } else {
        $("#AQueParienteRecurir").prop("hidden", false);
        $("#AQueParienteRecurirTitulo").prop("hidden", false);
    }
});
$("#InterrumpioTratamientoMedico").change(function () {
    if ($(this).val() === "false") {
        $("#TiempoInterrupcionTratamientoMedico").prop("hidden", true);
        $("#MotivoInterrupcionTratamientoMedico").prop("hidden", true);
        $("#TiempoInterrupcionPregunta").prop("hidden", true);
        $("#MotivoInterrupcionPregunta").prop("hidden", true);
        $("#TiempoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
        $("#MotivoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
    } else {
        $("#TiempoInterrupcionTratamientoMedico").prop("hidden", false);
        $("#MotivoInterrupcionTratamientoMedico").prop("hidden", false);
        $("#TiempoInterrupcionPregunta").prop("hidden", false);
        $("#MotivoInterrupcionPregunta").prop("hidden", false);
        $("#TiempoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
        $("#MotivoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
    }
});
$("#CuentaConAmigosVecinosCompanieroTrabajo").change(function () {
    if ($(this).val() === "false") {
        $("#QueAmigosVecinosCompanieroTrabajo").prop("hidden", true);
        $("#QueAmigosVecinosCompanieroTrabajoTirulo").prop("hidden", true);
        $("#QueAmigosVecinosCompanieroTrabajoValidacion").addClass("ocultar");
    } else {
        $("#QueAmigosVecinosCompanieroTrabajo").prop("hidden", false);
        $("#QueAmigosVecinosCompanieroTrabajoTirulo").prop("hidden", false);
    }
});
$("#AsisteAIntitucionComunitaria").change(function () {
    if ($(this).val() === "false") {
        $("#CualIntitucionComunitaria").prop("hidden", true);
        $("#CualIntitucionComunitariaTitulo").prop("hidden", true);
        $("#PersonaDeContactoIntitucionComunitaria").prop("hidden", true);
        $("#ConQuienSeContactaEnIntitucionComunitaria").prop("hidden", true);
        $("#CualIntitucionComunitariaValidacion").addClass("ocultar");
        $("#ConQuienSeContactaEnIntitucionComunitariaValidacion").addClass("ocultar");
    } else {
        $("#CualIntitucionComunitaria").prop("hidden", false);
        $("#CualIntitucionComunitariaTitulo").prop("hidden", false);
        $("#PersonaDeContactoIntitucionComunitaria").prop("hidden", false);
        $("#ConQuienSeContactaEnIntitucionComunitaria").prop("hidden", false);
    }
});
$("#DejoDeContactarAAlguien").change(function () {
    if ($(this).val() === "false") {
        $("#AQuienDejoDeContactar").prop("hidden", true);
        $("#AQuienDejoDeContactarTitulo").prop("hidden", true);
        $("#AQuienDejoDeContactarValidacion").addClass("ocultar");
    } else {
        $("#AQuienDejoDeContactar").prop("hidden", false);
        $("#AQuienDejoDeContactarTitulo").prop("hidden", false);
    }
});
$("#SeleccionOtrosConsultante").change(function () {
    if ($(this).val() === "false") {
        $("#CualOtraViolenciaConsultante").addClass("ocultar");
    } else {
        $("#CualOtraViolenciaConsultante").removeClass("ocultar");
    }
});
$("#SeleccionOtrosDiscapacitado").change(function () {
    if ($(this).val() === "false") {
        $("#CualOtraViolenciaDiscapacitado").addClass("ocultar");
    } else {
        $("#CualOtraViolenciaDiscapacitado").removeClass("ocultar");
    }
});
$("#ExisteConsultante").change(function () {
    if ($(this).val() === "true") {
        $("#div-consultante").removeClass("ocultar");
        $("#div-niveleducativoconsultante").removeClass("ocultar");
    } else {
        $("#div-consultante").addClass("ocultar"); 
        $("#div-niveleducativoconsultante").addClass("ocultar");
    }
});



/*cargar fecha por defecto*/
window.onload = FechaPorDefecto();
function FechaPorDefecto() {
    document.getElementById("VencimientoCud").defaultValue = "1920-01-01";
    document.getElementById("FechaInicioDiscapacidad").defaultValue = "1920-01-01";
    document.getElementById("FechaNacimientoConsultante").defaultValue = "1920-01-01";
}

/*Seccion para cargar plantilla de situacion habitacional.*/
window.onload = BuscarSituacionesHabitacionales();

function BuscarSituacionesHabitacionales() {
    $("#tbody-SituacionHabitacional").empty();
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/BuscarPlantillaSituacionHabitacional',
        data: {},
        success: function (sectoresViviendaMostrar) {
            /*
            * Se ejecuta cuando termina la petición y esta ha sido
            * correcta
            * */
            $("#SituacionesHabitacionales").empty();

            var ubicacionCaract = 0;

            $.each(sectoresViviendaMostrar, function (index, sectorVivienda) {
                $("#SituacionesHabitacionales").append('<div class="col-12 text-left RenglonGris">' + '<label class="control-label TextoNegroFormulario TextonegroCelu">' + '<u>' + "  " +
                    sectorVivienda.NombreSectorVivienda + '</u>' + '</label>' +
                    '<input type="hidden" name="SectoresViviendasID" value="' + sectorVivienda.SectorViviendaID + '"> ' +
                    '</div>');

                $.each(sectorVivienda.Caracteristicas, function (index, caracteristica) {

                    ubicacionCaract += 1;

                    var liniaInput = '<input type="Radio" class = "RadioNuevo" onclick="ActivarInput(' + caracteristica.SituacionHabitacionalID + ',' + sectorVivienda.SectorViviendaID + ')" id="' + sectorVivienda.SectorViviendaID + '" name="Sector_' + sectorVivienda.SectorViviendaID + '" value="' + caracteristica.SituacionHabitacionalID + '">';
                    if (ubicacionCaract == 1) {
                        liniaInput = '<input type="Radio" class = "RadioNuevo" onclick="ActivarInput(' + caracteristica.SituacionHabitacionalID + ',' + sectorVivienda.SectorViviendaID + ')" checked id="' + sectorVivienda.SectorViviendaID + '"name="Sector_' + sectorVivienda.SectorViviendaID + '" value=" ' + caracteristica.SituacionHabitacionalID + '">';
                    }

                    var lineaInputObservacion = "";
                    if (caracteristica.Observacion == true) {
                        lineaInputObservacion = '<input type="text" class="form-control form-control-rounded InputObservacionVivienda_' + sectorVivienda.SectorViviendaID + '" disabled onkeypress="return (event.charCode >= 48 && event.charCode <= 57)" min="1"  name="Observacion_' + caracteristica.SituacionHabitacionalID + '" id="Observacion_' + caracteristica.SituacionHabitacionalID + '">';
                    }

                    $("#SituacionesHabitacionales").append(
                        '<div class="col-6 col-md-3">' + '<label class="TextoNegroFormulario TextonegroCelu ">' + liniaInput + ' ' + caracteristica.NombreCaracteristicaSector + '</label>' +
                        lineaInputObservacion +
                        '</div>'
                    );
                });

                ubicacionCaract = 0;
            });

        },
        error: function (data) {
            /*
            * Se ejecuta si la peticón ha sido erronea
            * */
            alert("Problemas al tratar de enviar el formulario");
        }
    });
}
//Funcion para activar radios de plantilla de situacion haitacional
function ActivarInput(SituacionHabitacionalID, SectorViviendaID) {

    //PRIMERO BUSCAMOS TODOS LOS INPUT QUE SEAN DEL MISMO SECTOR VIVIENDA QUE EL ELEMENTO TILDADO
    var inputsDesactivar = document.getElementsByClassName("InputObservacionVivienda_" + SectorViviendaID);
    //BUSCAMOS SI ESE INPUT DE TIPO RADIO QUE FUE TILDADO TIENE OBSERVACION
    var inputDesactivar = document.getElementById("Observacion_" + SituacionHabitacionalID);
    if (inputDesactivar != null) {
        //SI ES DISTINTO DE NULL ES PORQUE OBVIAMENTE TIENE OBSERVACION
        //LUEGO RECORREMOS CADA UNO DE LOS INPUT DE SECTOR VIVIENDA EN COMUN
        for (var i = 0; i < inputsDesactivar.length; i++) {
            var inputDesactivarID = inputsDesactivar[i].id;
            //POR CADA UNO DE ESTOS INPUT, PREGUNTAMOS SI PERTENECE AL RADIO TILDADO, DE SER ASI LO ACTIVA, ES DECIR LE QUITA LA CLASE DESACTIVADA
            //SINO BLOQUEA EL RESTO DE LOS ELEMENTOS
            if (inputDesactivarID == inputDesactivar.id) {
                inputsDesactivar[i].disabled = false;
            }
            else {
                //SINO BLOQUEA EL ELEMENTO INPUT
                inputsDesactivar[i].disabled = true;
            }
        }
    }
    else {
        //EN CASO DE QUE EL RADIO TILDADO NO CONTENGA NINGUN INPUT, DESACTIVA TODO LO DE LA MISMA LINEA, ES DECIR DEL MISMO TIPO DE VIVIENDA.
        for (var i = 0; i < inputsDesactivar.length; i++) {
            inputsDesactivar[i].disabled = true;
            $(inputsDesactivar).val("");
        }
    }
}


/*Autocompletado de datos de persona.*/
$("#PersonaNombre").autocomplete({
    dataType: 'JSON',
    source: function (request, response) {
        jQuery.ajax({
            url: '../../Personas/BuscarPersonas',
            type: "post",
            dataType: "json",
            data: {
                texto: request.term,
            },
            success: function (personasMostrar) {
                if (personasMostrar.length == 0) {
                    LimpiarInfoPersona();
                }
                response($.map(personasMostrar, function (personaMostrar) {
                    return {
                        id: personaMostrar.PersonaID,
                        value: personaMostrar.PersonaApellidoNombre
                    }
                }))

            }
        })
    },
    select: function (e, ui) {
        $("#PersonaIDCrear").val(ui.item.id);
        $("#PersonaIDRelacionada").val(ui.item.id);
        $("#NombrePersonaRelacionadaCrear").val(ui.item.value);
        $("#PersonaIDRelacionEscuelas").val(ui.item.id);
        BuscarInfoPersona(ui.item.id);
    }
});
//funcion para controlar que cuando se borre todo lo escrito en el auto completa limpie todo los datos de persona
function ControlarAutocompletado() {
    var nombre = $("#PersonaNombre").val();
    var personaID = $("#PersonaIDCrear").val();
    if (nombre == "" && personaID != 0) {
        LimpiarInfoPersona();
    }
}
//funcion para limpiar todo los campos de perosona
function LimpiarInfoPersona() {
    $("#PersonaIDCrear").val(0);
    $("#PersonaNombreValidacion").addClass('ocultar');
    $("#PersonaConDiscapacidadExistenteValidacion").addClass('ocultar');
    $("#PersonaFechaNacimiento").val('');
    $("#PersonaDNI").val('');
    $("#PersonaDomicilio").val('');
    $("#PersonaTelefono").val('');
    $("#Obrasocialsino").val('');
    $("#Obrasocialcual").val('');
    $("#BotonModalRelacionInstitutoYPErsona").addClass("ocultar");
    $("#BotonCrearGrupoFamiliar").addClass("ocultar");
    $("#botonEditarGrupoFamiliar").addClass("ocultar");
    $("#botonEliminarGrupoFamiliar").addClass("ocultar");
    $("#botonEditarRelacionEscuelaconPersona").addClass("ocultar");
    $("#botonEliminarRelacionEscuelaconPersona").addClass("ocultar");
    BuscarListadoEscuelaPorPersona($("#PersonaIDCrear").val());
    BuscarGrupoFamiliar($("#PersonaIDCrear").val());
}
//funcion para buscar y cargar toda la informacion de la persona, esta funcion esta relacionada con el auto completar de persona que esta arriba
function BuscarInfoPersona(personaID) {
    $.ajax({
        type: "POST",
        url: '../../Personas/BuscarInfoPersona',
        data: { PersonaID: personaID },
        success: function (personaMostrar) {

            $("#PersonaIDCrear").val(personaMostrar.PersonaID);
            $("#PersonaNombre").val(personaMostrar.PersonaApellidoNombre);

            $("#PersonaFechaNacimiento").val(personaMostrar.PersonaFechaNacimientoString);
            $("#PersonaDNI").val(personaMostrar.PersonaDNI);
            $("#PersonaDomicilio").val(personaMostrar.PersonaDireccion);
            $("#PersonaTelefono").val(personaMostrar.PersonaTelefono);
            $("#Obrasocialcual").val(personaMostrar.ObraSocialCual);
            if (personaMostrar.PersonaObraSocial === true) {
                $("#Obrasocialsino").val("Sí");
            }
            else {
                $("#Obrasocialsino").val("No");
            }
            $("#PersonaIDRelacionada").val(personaMostrar.PersonaID);
            $("#NombrePersonaRelacionadaCrear").val(personaMostrar.PersonaApellidoNombre);
            $("#PersonaIDRelacionEscuelas").val(personaMostrar.PersonaID);
            $("#NombrePersonaRelacionada").val(personaMostrar.PersonaApellidoNombre);
            ValidacionDePersonaConDiscapacidadExistente(personaMostrar.PersonaID);
        },
        error: function (data) {

        }
    });
}
//autocompletar de localidades
$("#LocalidadesNombreCrearPersona").autocomplete({
    dataType: 'JSON',
    source: function (request, response) {
        jQuery.ajax({
            url: '../../Localidades/BuscarLocalidades',
            type: "post",
            dataType: "json",
            data: {
                texto: request.term,
            },
            success: function (localidadesMostrar) {
                response($.map(localidadesMostrar, function (localidadMostrar) {
                    return {
                        id: localidadMostrar.LocalidadesID,
                        value: localidadMostrar.LocalidadesNombre
                    }
                }))

            }
        })
    },
    select: function (e, ui) {
        $("#LocalidadesIDCrearPersona").val(ui.item.id);
        $("#LocalidadesNombreCrearPersona").val(ui.item.value);
    }
});

function GuardarLocalidad() {
    var localidadesnombre = $("#LocalidadesNombreCrear").val();
    var localidadesdepartamento = $("#LocalidadesDepartamento").val();
    var provinciasID = $("#ProvinciasID").val();
    var localidadesID = $("#LocalidadesIDCrear").val();


    $("#obligatorio-LocalidadesNombreCrear").addClass("ocultar");
    $("#existe-LocalidadesNombreCrear").addClass("ocultar");


    var registrarlocalidad = true;

    if (localidadesnombre == "") {
        registrar = false;
        //ESCRIBIMOS UN MENSAJE DEBAJO DEL INPUT QUE DIGA QUE ESE CAMPO ES OBLIGATORIO
        $("#obligatorio-LocalidadesNombreCrear").removeClass("ocultar");
    }

    $.ajax({
        type: "POST",
        url: '../../Localidades/ValidarNombreLocalidad',
        data: {
            LocalidadesNombre: localidadesnombre, LocalidadesDepartamento: localidadesdepartamento, ProvinciasID: provinciasID
        },
        success: function (Validacionlocalidad) {
            if (Validacionlocalidad == true) {
                if (registrarlocalidad == true) {
                    $.ajax({
                        type: "POST",
                        url: '../../Localidades/GuardarLocalidad',
                        data: {
                            LocalidadesNombre: localidadesnombre, LocalidadesDepartamento: localidadesdepartamento, ProvinciasID: provinciasID, LocalidadesID: localidadesID
                        },
                        success: function (localidadid) {
                            CerrarModalLocalidad();
                            BuscarInfoLocalidad(localidadid);
                            Swal.fire({
                                position: 'center',
                                icon: 'success',
                                title: 'La Localidad Fue guardada Correctamente',
                                showConfirmButton: false,
                                timer: 1500
                            })
                        },
                        error: function (data) {

                        }
                    });
                }
            }
            else {
                $("#existe-LocalidadesNombreCrear").removeClass("ocultar");
            }
        }
    });
}

function Cambiodevistaparcial() {
    $("#ModalPersona").modal("hide");
    setTimeout('$("#ModalLocalidad").modal("show");', 500);
    
}
function CerrarModalLocalidad() {
    $("#LocalidadesNombreCrear").val('');
    $("#LocalidadesDepartamento").val('');
    $("#obligatorio-LocalidadesNombreCrear").addClass("ocultar");
    $("#ProvinciasID").val('');
    cambiodeVistaLocalidadAPersona();
}
function cambiodeVistaLocalidadAPersona() {
    $("#ModalLocalidad").modal("hide");
    setTimeout('$("#ModalPersona").modal("show");', 500);
}
function BuscarInfoLocalidad(localidadesID) {

    $.ajax({
        type: "POST",
        url: '../../Localidades/BuscarInfoLocalidad',
        data: { LocalidadesID: localidadesID },
        success: function (localidadMostrar) {
            $("#LocalidadesIDCrearPersona").val(localidadMostrar.LocalidadesID);
            $("#LocalidadesNombreCrearPersona").val(localidadMostrar.LocalidadesNombreCompleto);
        },
        error: function (data) {
            alert("Problemas al buscar datos de la Localidad.");
        }
    });
}

//funcion para guardar una persona nueva que se realiza en la vista parcial de crear persona
function GuardarCrearPersona() {
    var personaid = $("#PersonaID").val();
    var personaApellidoNombre = $("#PersonaApellidoNombreCrear").val();
    var personaTelefono = $("#PersonaTelefonoCrear").val();
    var personaDni = $("#PersonaDNICrear").val();
    var personaFechaNacimiento = $("#PersonaFechaNacimientoCrear").val();
    var personaDireccion = $("#PersonaDireccionCrear").val();
    var localidadesID = $("#LocalidadesIDCrearPersona").val();
    var personaCorreo = $("#PersonaCorreoCrear").val();
    var personaSexo = $("#PersonaSexoCrear").val();
    var personaCovid = $("#PersonaCovidCrear").val();
    var personaObraSocial = $("#PersonaObraSocialCrear").val();
    var obraSocialCual = $("#ObraSocialCualCrear").val();
    //VER!!!
    //DE ENTRADA AGREGAN LA CLASE OCULTAR A LOS INPUTS
    $("#obligatorio-PersonaApellidoNombreCrear").addClass("ocultar");
    $("#obligatorio-PersonaTelefonoCrear").addClass("ocultar");
    $("#obligatorio-PersonaDNICrear").addClass("ocultar");
    $("#obligatorio-PersonaDireccionCrear").addClass("ocultar");

    var registrar = true;

    if (personaApellidoNombre == "") {
        registrar = false;
        //ESCRIBIMOS UN MENSAJE DEBAJO DEL INPUT QUE DIGA QUE ESE CAMPO ES OBLIGATORIO
        $("#obligatorio-PersonaApellidoNombreCrear").removeClass("ocultar");
    }
    if (personaTelefono == "") {
        registrar = false;
        //ESCRIBIMOS UN MENSAJE DEBAJO DEL INPUT QUE DIGA QUE ESE CAMPO ES OBLIGATORIO
        $("#obligatorio-PersonaTelefonoCrear").removeClass("ocultar");
    }
    if (personaDni == "") {
        registrar = false;
        //ESCRIBIMOS UN MENSAJE DEBAJO DEL INPUT QUE DIGA QUE ESE CAMPO ES OBLIGATORIO
        $("#obligatorio-PersonaDNICrear").removeClass("ocultar");
    }
    if (personaDireccion == "") {
        registrar = false;
        //ESCRIBIMOS UN MENSAJE DEBAJO DEL INPUT QUE DIGA QUE ESE CAMPO ES OBLIGATORIO
        $("#obligatorio-PersonaDireccionCrear").removeClass("ocultar");
    }


    if (registrar == true) {

        $.ajax({
            type: "POST",
            url: '../../Personas/GuardarPersona',
            data: {
                PersonaApellidoNombre: personaApellidoNombre, PersonaTelefono: personaTelefono, PersonaDNI: personaDni,
                PersonaFechaNacimiento: personaFechaNacimiento, PersonaDireccion: personaDireccion, LocalidadesID: localidadesID,
                PersonaCorreo: personaCorreo, PersonaSexo: personaSexo, PersonaCovid: personaCovid, PersonaObraSocial: personaObraSocial,
                ObraSocialCual: obraSocialCual, PersonaID: personaid
            },
            success: function (PersonaID) {
                BuscarInfoPersona(PersonaID);
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'La Persona Fue Guardado Correctamente',
                    showConfirmButton: false,
                    timer: 1500
                })
                $('#ModalPersona').modal('hide');
            },
            error: function (data) {
                /*
                * Se ejecuta si la peticón ha sido erronea
                * */

            }

        });
    }
}

//funcion para validar que la persona seleccionada en el auto completar de persona no exista como persona con discapacidad
function ValidacionDePersonaConDiscapacidadExistente(personaID) {
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/ValidacionDePersonaConDiscapacidadExistente',
        data: {
            PersonaID: personaID
        },
        success: function (Validacion) {

            if (Validacion === true) {
                $("#PersonaConDiscapacidadExistenteValidacion").addClass("ocultar");
                $("#PersonaNombreValidacion").addClass("ocultar");
                $("#BotonModalRelacionInstitutoYPErsona").removeClass("ocultar");
                $("#BotonCrearGrupoFamiliar").removeClass("ocultar");
                $("#ColumnaEditarGRupoFamiliar").removeClass("ocultar");
                $("#ColumnaEliminarGRupoFamiliar").removeClass("ocultar");
                $("#ColumnaEditarInstitutoRelacionado").removeClass("ocultar");
                $("#ColumnaEliminarInstitutoRelacionado").removeClass("ocultar");
                BuscarGrupoFamiliar(personaID);
                BuscarListadoEscuelaPorPersona(personaID);
            }
            else {
                $("#PersonaConDiscapacidadExistenteValidacion").removeClass("ocultar");
                $("#PersonaNombreValidacion").addClass("ocultar");
                $("#BotonModalRelacionInstitutoYPErsona").addClass("ocultar");
                $("#BotonCrearGrupoFamiliar").addClass("ocultar");
                $("#ColumnaEditarGRupoFamiliar").addClass("ocultar");
                $("#ColumnaEliminarGRupoFamiliar").addClass("ocultar");
                $("#ColumnaEditarInstitutoRelacionado").addClass("ocultar");
                $("#ColumnaEliminarInstitutoRelacionado").addClass("ocultar");
                BuscarGrupoFamiliar(personaID, 1);
                BuscarListadoEscuelaPorPersona(personaID, 1);
            }
        },
        error: function (data) {
            alert("Problemas al tratar de enviar el formulario");
        }
    });
}
//funcion para limpiar todo el formulario de grupo familiar de la vista parcial de crear grupo familiar
function VaciarFormulario(origen) {
    $("#GrupoFamiliarID").val(0);
    $("#GrupoFamiliarApellidoNombreCrear").val('');
    $("#GrupoFamiliarDNICrear").val('');
    $("#GrupoFamiliarSaludCrear").val('');
    $("#GrupoFamiliarIngresosCrear").val('');
    $("#GrupoFamiliarNacimientoCrear").val('');
    $("#GrupoFamiliarVinculoCrear").val('');
    $("#GrupoFamiliarEscolaridadCrear").val('');
    $("#GrupoFamiliarOcupacionCrear").val('');
    $('#GrupoFamiliarSexoCrear').val(0);
    $('#NombrePersonaRelacionadaCrear').prop("disabled", true);
    $("#botonCrearPersonaGrupoFamiliar").prop("hidden", true);

    $("#botonguardar").prop("hidden", false);
    $("#botoncancelar").prop("hidden", false);
    $("#BotonVolver").addClass("ocultar");
    if (origen == 1) {
        $("#botonguardar").prop("hidden", false);
        $("#botoncancelar").prop("hidden", false);

        $("#BotonVolver").addClass("ocultar");
        $("#ModalCrearGrupoFamiliar").modal("show");
    }
}


//Buscar Para completar Tabla de Grupo Familiar
function BuscarGrupoFamiliar(personaID, origen) {
    $("#tbody-GrupoFamiliar").empty();
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/BuscarGrupoFamiliar',
        data: { PersonaID: personaID },
        success: function (grupofamiliaresmostrar) {

            $("#tbody-GrupoFamiliar").empty();
            if (origen == 1) {
                $.each(grupofamiliaresmostrar, function (index, grupofamiliar) {
                    $("#tbody-GrupoFamiliar").append('<tr>' +
                        '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarApellidoNombre + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar860 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarNacimientoString + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarSexoString + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar640 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarVinculo + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1430 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarEscolaridad + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar640 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarDNI + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarOcupacion + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarSalud + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarIngresos + '</td>' +
                        '</tr>'
                    );
                });
            } else {
                $.each(grupofamiliaresmostrar, function (index, grupofamiliar) {
                    $("#tbody-GrupoFamiliar").append('<tr>' +
                        '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarApellidoNombre + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar860 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarNacimientoString + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarSexoString + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar640 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarVinculo + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1430 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarEscolaridad + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar640 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarDNI + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarOcupacion + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarSalud + '</td>' +
                        '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarIngresos + '</td>' +
                        '<td class="text-center TextoNegroTablas tdBotones ContenidoTablaGris  ">' +
                        '<a id="botonEditarGrupoFamiliar" class="btn-circle-index" onclick="DatosIntegranteDeFamilia(' + grupofamiliar.GrupoFamiliarID + ')" >' +
                        '<img src="../Content/dashtreme-master/assets/images/iconos menu/editar.png" class="icono-tabla" data-toggle="modal" data-target="#ModalCrearGrupoFamiliar"/>' +
                        '</a>' +
                        '<td class="text-center TextoNegroTablas tdBotones ContenidoTablaGris  ">' +
                        '<a id="botonEliminarGrupoFamiliar" class="btn-circle-index" onclick="EliminarGrupoFamiliar(' + grupofamiliar.GrupoFamiliarID + ');"><img src="../Content/dashtreme-master/assets/images/iconos menu/basura.png" class="icono-tabla" /></a>' +
                        '</td>' + '</tr>'
                    );
                });
            }
        },
        error: function (data) {
        }
    });

}
//funcio para guardar un grupofamiliar nuevo desde la vista parcial de crear un grupo familiar
function GuardarGrupoFamiliar() {

    var grupoFamiliarID = $("#GrupoFamiliarID").val();//SI ES DISTINTO DE 0, QUIERE DECIR QUE EDITA
    var grupoFamiliarApellidoNombre = $("#GrupoFamiliarApellidoNombreCrear").val();
    var grupoFamiliarDNI = $("#GrupoFamiliarDNICrear").val();
    var grupoFamiliarSexo = $("#GrupoFamiliarSexoCrear").val();
    var grupoFamiliarSalud = $("#GrupoFamiliarSaludCrear").val();
    var grupoFamiliarIngresos = $("#GrupoFamiliarIngresosCrear").val();
    var grupoFamiliarNacimiento = $("#GrupoFamiliarNacimientoCrear").val();
    var grupoFamiliarVinculo = $("#GrupoFamiliarVinculoCrear").val();
    var grupoFamiliarEscolaridad = $("#GrupoFamiliarEscolaridadCrear").val();
    var grupoFamiliarOcupacion = $("#GrupoFamiliarOcupacionCrear").val();
    var personaID = $("#PersonaIDRelacionada").val();
    $("#campo-obligatorio-GrupoFamiliarApellidoNombreCrear").addClass("ocultar");
    $("#campo-obligatorio-GrupoFamiliarDNICrear").addClass("ocultar"); 
    $("#campo-obligatorio-GrupoFamiliarIngresosCrear").addClass("ocultar");
    $("#campo-obligatorio-GrupoFamiliarVinculoCrear").addClass("ocultar");
    $("#campo-obligatorio-NombrePersonaRelacionadaCrear").addClass("ocultar");
    $("#campo-obligatorio-GrupoFamiliarSexo").addClass("ocultar");
    $("#IngresoValidacion").addClass("ocultar");
    $("#FechaValidacion").addClass("ocultar");

    var guardar = true;

    //validacion de sexo
    if (grupoFamiliarSexo == "" || grupoFamiliarSexo == null || grupoFamiliarSexo == 0) {
        guardar = false;
        $("#campo-obligatorio-GrupoFamiliarSexo").removeClass("ocultar");
    }

    //validacion de ingresos
    if (grupoFamiliarIngresos > 9999999 || grupoFamiliarIngresos < -1 || grupoFamiliarIngresos == 0) {
        guardar = false;
        $("#campo-obligatorio-GrupoFamiliarIngresosCrear").removeClass("ocultar");
    }


    //Validacion de fecha
    var date = new Date;
    var mesActual = date.getMonth() + 1;
    var dia = date.getDate();
    if (mesActual < 10) {
        if (dia < 10) {
            var FechaHoy = date.getFullYear() + "-0" + (date.getMonth() + 1) + "-0" + date.getDate();
        }
        else {
            var FechaHoy = date.getFullYear() + "-0" + (date.getMonth() + 1) + "-" + date.getDate();
        }

    }
    else {
        if (dia < 10) {
            var FechaHoy = date.getFullYear() + "-" + (date.getMonth() + 1) + "-0" + date.getDate();
        }
        else {
            var FechaHoy = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        }
    }
    var FechaPredeterminada = "1920-01-01";

    if (grupoFamiliarNacimiento <= FechaPredeterminada || grupoFamiliarNacimiento == null || grupoFamiliarNacimiento > FechaHoy) {
        guardar = false;
        $("#FechaValidacion").removeClass("ocultar");
    }
    //Validaciones de campos obligatorios
   
    if (grupoFamiliarApellidoNombre == "") {
        guardar = false;
        $("#campo-obligatorio-GrupoFamiliarApellidoNombreCrear").removeClass("ocultar");
    }

    if (grupoFamiliarDNI == "") {
        guardar = false;
        $("#campo-obligatorio-GrupoFamiliarDNICrear").removeClass("ocultar");
    }

    if (grupoFamiliarIngresos == "") {
        guardar = false;

        $("#campo-obligatorio-GrupoFamiliarIngresosCrear").removeClass("ocultar");
    }
    if (grupoFamiliarVinculo == "") {
        guardar = false;

        $("#campo-obligatorio-GrupoFamiliarVinculoCrear").removeClass("ocultar");
    }
    if (personaID == 0) {
        guardar = false;

        $("#campo-obligatorio-NombrePersonaRelacionadaCrear").removeClass("ocultar");
    }

    if (guardar == true) {

        $.ajax({
            type: "POST",
            url: '../../GrupoFamiliars/GuardarGrupoFamiliar',
            data: {
                GrupoFamiliarApellidoNombre: grupoFamiliarApellidoNombre,
                GrupoFamiliarDNI: grupoFamiliarDNI,
                GrupoFamiliarSexo: grupoFamiliarSexo,
                GrupoFamiliarNacimiento: grupoFamiliarNacimiento,
                GrupoFamiliarSalud: grupoFamiliarSalud,
                GrupoFamiliarIngresos: grupoFamiliarIngresos,
                GrupoFamiliarVinculo: grupoFamiliarVinculo,
                GrupoFamiliarEscolaridad: grupoFamiliarEscolaridad,
                GrupoFamiliarOcupacion: grupoFamiliarOcupacion,
                PersonaID: personaID,
                GrupoFamiliarID: grupoFamiliarID
            },
            success: function (guardado) {
                if (guardado === true) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'El Pariente Fue guardado Correctamente En Grupo Familiar',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    BuscarInfoPersona(personaID);
                    VaciarFormulario();
                    $('#ModalCrearGrupoFamiliar').modal('hide');
                } else {
                    $("#campo-obligatorio-GrupoFamiliarDNIEXISTENTE").removeClass("ocultar");
                }

            },
            error: function (data) {
                alert("Problemas al tratar de enviar el formulario");
            }
        });
    }
}
//Funcion que nos permite completar todo el formulario de la vista de crear grupo familiar para poder editar un grupo familiar
function DatosIntegranteDeFamilia(grupoFamiliarID) {
    $.ajax({
        type: "POST",
        url: '../../GrupoFamiliars/DatosIntegranteDeFamilia',
        data: { GrupoFamiliarID: grupoFamiliarID },
        success: function (grupofamiliarmostrar) {
            $("#NombrePersonaRelacionadaCrear").prop("disabled", true);
            $("#GrupoFamiliarID").val(grupofamiliarmostrar.GrupoFamiliarID);
            $("#GrupoFamiliarApellidoNombreCrear").val(grupofamiliarmostrar.GrupoFamiliarApellidoNombre);
            $("#GrupoFamiliarDNICrear").val(grupofamiliarmostrar.GrupoFamiliarDNI);
            $("#GrupoFamiliarSexoCrear").val(grupofamiliarmostrar.GrupoFamiliarSexo);
            $("#GrupoFamiliarSaludCrear").val(grupofamiliarmostrar.GrupoFamiliarSalud);
            $("#GrupoFamiliarIngresosCrear").val(grupofamiliarmostrar.GrupoFamiliarIngresos);
            $("#GrupoFamiliarNacimientoCrear").val(grupofamiliarmostrar.GrupoFamiliarNacimientoString);
            $("#GrupoFamiliarVinculoCrear").val(grupofamiliarmostrar.GrupoFamiliarVinculo);
            $("#GrupoFamiliarEscolaridadCrear").val(grupofamiliarmostrar.GrupoFamiliarEscolaridad);
            $("#GrupoFamiliarOcupacionCrear").val(grupofamiliarmostrar.GrupoFamiliarOcupacion);
            $("#PersonaIDRelacionada").val(grupofamiliarmostrar.Personas.PersonaID);
            $("#NombrePersonaRelacionadaCrear").val(grupofamiliarmostrar.Personas.PersonaApellidoNombre);

            $("#botonguardar").prop("hidden", false);
            $("#botoncancelar").prop("hidden", false);
            $("#BotonVolver").addClass("ocultar");

            //$("#ModalCrearGrupoFamiliar").modal("show");
        },
        error: function (data) {
            alert("Problemas al buscar datos del grupo familiar.");
        }
    });
}
//funcion que nos permite eliminar un integrante del grupo familiar dentro de la vista de crear persona con discapacidad
function EliminarGrupoFamiliar(GrupoFamiliarID) {
    var personaID = $("#PersonaIDCrear").val();
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Esta seguro que desea eliminar este Familiar?',
        text: "Si la eliminas, sera para siempre",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, Eliminar',
        cancelButtonText: 'No, cancelar!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '../../GrupoFamiliars/EliminarGrupoFamiliar',
                data: { id: GrupoFamiliarID },
                success: function (data) {
                    BuscarInfoPersona(personaID)
                    swalWithBootstrapButtons.fire(
                        'Eliminado!',
                        'Has Eliminado a este Familiar.',
                        'success'
                    )
                },
                error: function (data) {
                    alert("Problemas al tratar de enviar el formulario");
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
        }
    })

}
//funcion para validad todas las casillas requeridas para crear una persona con discapacidad nueva
function ValidacionesCrear() {
    $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled",true);
    var personaNombre = $("#PersonaNombre").val();
    var personaID = $("#PersonaIDCrear").val();
    var existeConsultante = $("#ExisteConsultante").val();
    var nombreConsultante = $("#NombreConsultante").val();
    var fechaNacimientoConsultante = $("#FechaNacimientoConsultante").val();
    var dniConsultante = $("#DniConsultante").val();
    var cudExistente = $("#CudExistente").val();
    var numeroCUD = $("#NumeroCUD").val();
    var vencimientoCud = $("#VencimientoCud").val();
    var inicioDiscapacidadNacimiento = $("#InicioDiscapacidadNacimiento").val();
    var fechaInicioDiscapacidad = $("#FechaInicioDiscapacidad").val();
    var diagnosticoEnfermedad = $("#DiagnosticoEnfermedad").val();
    var detalleDiagnosticoEnfermedad = $("#DetalleDiagnosticoEnfermedad").val();
    var tratamientoMedico = $("#TratamientoMedico").val();
    var detalleTratamientoMedico = $("#DetalleTratamientoMedico").val();
    var lugarTratamientoMedico = $("#LugarTratamientoMedico").val();
    var interrumpioTratamientoMedico = $("#InterrumpioTratamientoMedico").val();
    var tiempoInterrupcionTratamientoMedico = $("#TiempoInterrupcionTratamientoMedico").val();
    var motivoInterrupcionTratamientoMedico = $("#MotivoInterrupcionTratamientoMedico").val();
    var diagnostico = $("#Diagnostico").val();
    var aQueParienteRecurir = $("#AQueParienteRecurir").val();
    var cuentaConAmigosVecinosCompanieroTrabajo = $("#CuentaConAmigosVecinosCompanieroTrabajo").val();
    var queAmigosVecinosCompanieroTrabajo = $("#QueAmigosVecinosCompanieroTrabajo").val();
    var asisteAIntitucionComunitaria = $("#AsisteAIntitucionComunitaria").val();
    var cualIntitucionComunitaria = $("#CualIntitucionComunitaria").val();
    var conQuienSeContactaEnIntitucionComunitaria = $("#ConQuienSeContactaEnIntitucionComunitaria").val();
    var dejoDeContactarAAlguien = $("#DejoDeContactarAAlguien").val();
    var aQuienDejoDeContactar = $("#AQuienDejoDeContactar").val();
    var cuentaConParienteAQuienRecurir = $("#CuentaConParienteAQuienRecurir").val();


    var date = new Date;
    var date = new Date;
    var mesActual = date.getMonth() + 1;
    var dia = date.getDate();
    if (mesActual < 10) {
        if (dia < 10) {
            var FechaHoy = date.getFullYear() + "-0" + (date.getMonth() + 1) + "-0" + date.getDate();
        }
        else {
            var FechaHoy = date.getFullYear() + "-0" + (date.getMonth() + 1) + "-" + date.getDate();
        }

    }
    else {
        if (dia < 10) {
            var FechaHoy = date.getFullYear() + "-" + (date.getMonth() + 1) + "-0" + date.getDate();
        }
        else {
            var FechaHoy = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
        }
    }
    var FechaPredeterminada = "1920-01-01";
    var validacionGuardado = true;


    $("#PersonaNombreValidacion").addClass("ocultar");
    $("#NombreConsultanteValidacion").addClass("ocultar");
    $("#FechaNacimientoConsultanteValidacion").addClass("ocultar");
    $("#DniConsultanteValidacion").addClass("ocultar");
    $("#NumeroCUDValidacion").addClass("ocultar");
    $("#VencimientoCudValidacion").addClass("ocultar");
    $("#FechaInicioDiscapacidadValidacion").addClass("ocultar");
    $("#DetalleDiagnosticoEnfermedadValidacion").addClass("ocultar");
    $("#DetalleTratamientoMedicoValidacion").addClass("ocultar");
    $("#LugarTratamientoMedicoValidacion").addClass("ocultar");
    $("#TiempoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
    $("#MotivoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
    $("#DiagnosticoValidacion").addClass("ocultar");
    $("#AQueParienteRecurirValidacion").addClass("ocultar");
    $("#QueAmigosVecinosCompanieroTrabajoValidacion").addClass("ocultar");
    $("#CualIntitucionComunitariaValidacion").addClass("ocultar");
    $("#ConQuienSeContactaEnIntitucionComunitariaValidacion").addClass("ocultar");
    $("#AQuienDejoDeContactarValidacion").addClass("ocultar");

    if (diagnostico == "" || diagnostico == null) {
        $("#DiagnosticoValidacion").removeClass("ocultar");
        validacionGuardado = false;
    }

    //Validacion cuando selecciona que si completa la planilla un consultante
    if (existeConsultante == 'true') {
        if (nombreConsultante == '') {
            $("#NombreConsultanteValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
        if (fechaNacimientoConsultante <= FechaPredeterminada || fechaNacimientoConsultante == null || fechaNacimientoConsultante > FechaHoy) {
            $("#FechaNacimientoConsultanteValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
        if (dniConsultante == 0) {
            validacionGuardado = false;
            $("#DniConsultanteValidacion").removeClass("ocultar");
        }
    }

    //Validacion cuando selecciona que tiene un CUD.
    if (cudExistente == 1) {
        if (numeroCUD == '' || numeroCUD == null || numeroCUD == 0) {
            $("#NumeroCUDValidacion").removeClass("ocultar");
            validacionGuardado = false;

        }
        if (vencimientoCud == FechaPredeterminada || vencimientoCud < FechaPredeterminada || vencimientoCud == null) {
            $("#VencimientoCudValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }

    if (cuentaConParienteAQuienRecurir == 'true') {
        if (aQueParienteRecurir == '' || aQueParienteRecurir == null) {
            $("#AQueParienteRecurirValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }
    if (cuentaConAmigosVecinosCompanieroTrabajo == 'true') {
        if (queAmigosVecinosCompanieroTrabajo == '' || queAmigosVecinosCompanieroTrabajo == null) {
            $("#QueAmigosVecinosCompanieroTrabajoValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }

    if (asisteAIntitucionComunitaria == 'true') {
        if (cualIntitucionComunitaria == '' || cualIntitucionComunitaria == null) {
            $("#CualIntitucionComunitariaValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
        if (conQuienSeContactaEnIntitucionComunitaria == '' || conQuienSeContactaEnIntitucionComunitaria == null) {
            $("#ConQuienSeContactaEnIntitucionComunitariaValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }

    if (dejoDeContactarAAlguien == 'true') {
        if (aQuienDejoDeContactar == '' || aQuienDejoDeContactar == null) {
            $("#AQuienDejoDeContactarValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }

    //Validacion Cuando seleccionan que la discapacidad fue adquirida
    if (inicioDiscapacidadNacimiento == 'false') {
        if (fechaInicioDiscapacidad <= FechaPredeterminada || fechaInicioDiscapacidad == null || fechaInicioDiscapacidad > FechaHoy) {
            $("#FechaInicioDiscapacidadValidacion").removeClass("ocultar");

            validacionGuardado = false;
        }
    }

    //Validacion cuando se selecciona que tiene un diagnostico de enfermedad.
    if (diagnosticoEnfermedad == 'true') {
        if (detalleDiagnosticoEnfermedad == '') {
            $("#DetalleDiagnosticoEnfermedadValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }

    //Validacion cuando se selecciona que actualmente esta realizando un tratamiento medico.
    if (tratamientoMedico == 'true') {
        if (detalleTratamientoMedico == '') {
            $("#DetalleTratamientoMedicoValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
        if (lugarTratamientoMedico == '') {
            $("#LugarTratamientoMedicoValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }

    //Validacion cuando se selecciona que actualmente esta realizando un tratamiento medico.
    if (interrumpioTratamientoMedico == 'true') {
        if (tiempoInterrupcionTratamientoMedico == "") {
            $("#TiempoInterrupcionTratamientoMedicoValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
        if (motivoInterrupcionTratamientoMedico == "") {
            $("#MotivoInterrupcionTratamientoMedicoValidacion").removeClass("ocultar");
            validacionGuardado = false;
        }
    }
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/ValidacionDePersonaConDiscapacidadExistente',
        data: {
            PersonaID: personaID
        },
        success: function (Validacion) {
            if (Validacion === true) {
                if (personaNombre != "" && personaID != 0) {
                    if (validacionGuardado === true ) {
                        $.ajax({
                            type: "POST",
                            url: '../../Personas/BuscarInfoPersona',
                            data: { PersonaID: personaID },
                            success: function (personaMostrar) {
                                if (personaMostrar.PersonaApellidoNombre == personaNombre) {
                                    ValidacionExistePersona = true;
                                    $("#PersonaIDVAlidacion").addClass("ocultar");
                                    if (ValidacionExistePersona === true) {
                                        Swal.fire({
                                            position: 'center',
                                            icon: 'success',
                                            title: 'La Persona Con Discapacidad se Guardo Correctamente',
                                            showConfirmButton: false,
                                            timer: 3000
                                        })

                                        document.getElementById("BotonGuardarDiscapacitado").click();
                                        $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
                                    }
                                } else {
                                    LimpiarInfoPersona();
                                    $("#PersonaNombreValidacion").removeClass("ocultar");
                                    $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
                                }
                            },
                            error: function (data) {

                            }
                        });
                    } else {
                        Swal.fire({
                            position: 'center',
                            icon: 'error',
                            title: 'Complete todos los campos',
                            showConfirmButton: false,
                            timer: 1000
                        })
                        $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
                    }
                }
                else {
                    $("#PersonaNombreValidacion").removeClass("ocultar");
                    Swal.fire({
                        position: 'center',
                        icon: 'error',
                        title: 'Complete todos los campos',
                        showConfirmButton: false,
                        timer: 1000
                    })
                    $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
                }

            }
            else {
                $("#PersonaConDiscapacidadExistenteValidacion").removeClass("ocultar");
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Complete todos los campos correctamente',
                    showConfirmButton: false,
                    timer: 10000
                })
                $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
            }
        },
        error: function (data) {
            alert("Problemas al tratar de enviar el formulario");
            $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
        }
    });
    //Validacion para el guardado de la pagina completa
   
}



//funcion que busca todas las escuelas en las que este relacionada una persona y la carga en la tabla (tbody-RelacionInstitutoYPersona) de la vista
function BuscarListadoEscuelaPorPersona(personaID, origen) {
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/BuscarListadoEscuelaPorPersona',
        data: { PersonaID: personaID },
        success: function (RelacionesInstitutoYPersonaMostrar) {
            $('#ModalCrearRelacionInstitutoYPersona').modal('hide');
            $("#tbody-RelacionInstitutoYPersona").empty();

            if (origen == 1) {
                $.each(RelacionesInstitutoYPersonaMostrar, function (index, relacion) {
                    $("#tbody-RelacionInstitutoYPersona").append('<tr>' +
                        '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + relacion.Escuela.EscuelaNombre + '</td>'
                    );
                });
            } else {
                $.each(RelacionesInstitutoYPersonaMostrar, function (index, relacion) {
                    $("#tbody-RelacionInstitutoYPersona").append('<tr>' +
                        '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + relacion.Escuela.EscuelaNombre + '</td>' +
                        '<td class="text-center TextoNegroTablas tdBotones ContenidoTablaGris  ">' +
                        '<a id="botonEditarRelacionEscuelaconPersona" class="btn-circle-index" onclick="EditarRelacionInstitutoYPersona(' + relacion.RelacionInstitutoYPersonaID + ')" >' +
                        '<img src="../Content/dashtreme-master/assets/images/iconos menu/editar.png" class="icono-tabla" data-toggle="modal" data-target="#ModalCrearRelacionInstitutoYPersona"/>' +
                        '</a>' + '</td>' +
                        '<td class="text-center TextoNegroTablas tdBotones ContenidoTablaGris">' +
                        '<a id="botonEliminarRelacionEscuelaconPersona" class="btn-circle-index " onclick="EliminarRelacionEscuelaYPersona(' + relacion.RelacionInstitutoYPersonaID + ');"><img src="../Content/dashtreme-master/assets/images/iconos menu/basura.png" class="icono-tabla" /></a>' +
                        '</td>' + '</tr>'
                    );
                });
            }
            
        },
        error: function (data) {
            /*
            * Se ejecuta si la peticón ha sido erronea
            * */
            alert("Problemas al tratar de enviar el formulario");
        }
    });

}

function ControlarAutocompletadoEscuela() {
    var nombre = $("#EscuelaNombre").val();
    var escuelaIDRelacion = $("#EscuelaIDRelacion").val();
    if (nombre == "" && escuelaIDRelacion != 0) {
        LimpiarFormularioRelacionEscuelayPersona(0);
    }
}


//funcion que nos permite guardar una institucion a la que asiste la persona con discapacidad
function GuardarRelacionInstitutoYPersona() {
    $("#EscuelaRepetidaValidacion").addClass("ocultar");
    $("#EscuelaNombreValidacion").addClass("ocultar");
    var relacionInstitutoYPersonaIDModal = $("#RelacionInstitutoYPersonaIDModal").val();
    var escuelaIDRelacion = $("#EscuelaIDRelacion").val();
    var personaIDRelacionEscuelas = $("#PersonaIDRelacionEscuelas").val();
    var nombre = $("#EscuelaNombre").val();
    if (escuelaIDRelacion > 0) {
        $.ajax({
            type: "POST",
            url: '../../PersonaConDiscapacidads/GuardarRelacionInstitutoYPersona',
            data: { PersonaID: personaIDRelacionEscuelas, EscuelaID: escuelaIDRelacion, RelacionInstitutoYPersonaID: relacionInstitutoYPersonaIDModal, NombreEscuela: nombre },
            success: function (personaID) {
                if (personaID > 0) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'El Colegio Fue Agregado Correctamente',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    BuscarListadoEscuelaPorPersona(personaID);
                    LimpiarFormularioRelacionEscuelayPersona(0);
                }
                if (personaID == -1) {
                    $("#EscuelaRepetidaValidacion").removeClass("ocultar");
                } else if (personaID == 0) {
                    $("#EscuelaNombreValidacion").removeClass("ocultar");
                }

            },
            error: function (personaID) {
                alert("Problemas al buscar datos de la institucion.");
            }
        });
    } else {
        $("#EscuelaNombreValidacion").removeClass("ocultar");
        
    }
    
}
//funcion para limpiar el formulario para cargar un instituto o colegio al listado de la persona con discapacidad
function LimpiarFormularioRelacionEscuelayPersona(origen) {
    $("#EscuelaNombre").val('');
    $("#EscuelaIDRelacion").val(0); EscuelaRepetidaValidacion
    $("#EscuelaNombreValidacion").addClass("ocultar");
    $("#EscuelaRepetidaValidacion").addClass("ocultar");
    if (origen == 1) {
        $("#ModalCrearRelacionInstitutoYPersona").modal("show");
    }

}
//funcion para cargar los datos en la vista parcial de la relacion entre persona y escuela o instituto
function EditarRelacionInstitutoYPersona(relacionInstitutoYPersonaID) {
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/EditarRelacionInstitutoYPersona',
        data: { RelacionInstitutoYPersonaID: relacionInstitutoYPersonaID },
        success: function (RelacionInstitutoYPersonaMostrar) {
            $("#RelacionInstitutoYPersonaIDModal").val(RelacionInstitutoYPersonaMostrar.RelacionInstitutoYPersonaID);
            $("#EscuelaIDRelacion").val(RelacionInstitutoYPersonaMostrar.Escuela.EscuelaID);
            $("#EscuelaNombre").val(RelacionInstitutoYPersonaMostrar.Escuela.EscuelaNombre);
            $("#PersonaIDRelacionEscuelas").val(RelacionInstitutoYPersonaMostrar.Persona.PersonaID);
        },
        error: function (data) {
            alert("Problemas al buscar datos del grupo familiar.");
        }
    });
}
//autocompletado de escuela
$("#EscuelaNombre").autocomplete({
    dataType: 'JSON',
    source: function (request, response) {
        jQuery.ajax({
            url: '../../Escuelas/BuscarEscuelas',
            type: "post",
            dataType: "json",
            data: {
                texto: request.term,
            },
            success: function (escuelaMostrar) {
                response($.map(escuelaMostrar, function (escuela) {
                    return {
                        id: escuela.EscuelaID,
                        value: escuela.EscuelaNombre
                    }
                }))

            }
        })
    },
    select: function (e, ui) {
        $("#EscuelaIDRelacion").val(ui.item.id);
        $("#EscuelaNombre").val(ui.item.id);
    }
});
//funcion para eliminar una escuela de la lista a la que asiste el discapacitado
function EliminarRelacionEscuelaYPersona(relacionInstitutoYPersonaID) {
    var personaID = $("#PersonaIDCrear").val();
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Esta seguro que desea eliminar este Instituto de la lista?',
        text: "Si la eliminas, sera para siempre",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, Eliminar',
        cancelButtonText: 'No, cancelar!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '../../PersonaConDiscapacidads/EliminarRelacionEscuelaYPersona',
                data: { id: relacionInstitutoYPersonaID },
                success: function (data) {
                    BuscarListadoEscuelaPorPersona(personaID)
                    swalWithBootstrapButtons.fire(
                        'Eliminado!',
                        'Has Eliminado a este Instituto Correctamente.',
                        'success'
                    )
                },
                error: function (data) {
                    alert("Problemas al tratar de enviar el formulario");
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
        }
    })
}


//Boton para preguntar si quiere volver al index sin guardar ningun dato
function VolveraVistaIndex() {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Esta seguro que desea volver?',
        text: "Si vuelve sus datos no seran guardados",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, Volver',
        cancelButtonText: 'No, cancelar!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            location.href = '../../PersonaConDiscapacidads/Index';
        
        } else if (result.dismiss === Swal.DismissReason.cancel) {
        }
    })

}