
//funcion utilizada para mostrar todo los datos en vista
function BuscarDetalleDiscapacitado(ID) {
    var id = ID;
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/BuscarDetalleDiscapacitado',
        data: { DiscapacitadoID: id },
        success: function (discapacitadomostrar) {
            
            BuscarListadoEscuelaPorPersona(discapacitadomostrar.Persona.PersonaID);
            BuscarGrupoFamiliar(discapacitadomostrar.Persona.PersonaID);
            $("#PersonaIDCrear").val(discapacitadomostrar.Persona.PersonaID);
            $("#PersonaIDRelacionEscuelas").val(discapacitadomostrar.Persona.PersonaID);
            $("#PersonaIDRelacionada").val(discapacitadomostrar.Persona.PersonaID);
            $("#NombrePersonaRelacionadaCrear").val(discapacitadomostrar.Persona.PersonaApellidoNombre);
            
            $("#NumeroCUD").val(discapacitadomostrar.NumeroCUD);
            $("#VencimientoCud").val(discapacitadomostrar.VencimientoCud);
            if ($("#NumeroCUD").val() != 0 && $("#NumeroCUD").val() != "") {
                $("#NumeroCUD").prop("hidden", false);
                $("#VencimientoCud").prop("hidden", false);
                $("#VencimientoCUDTitulo").prop("hidden", false);
                $("#NumeroCUDTitulo").prop("hidden", false);
            } else {
                $("#NumeroCUD").prop("hidden", true);
                $("#VencimientoCud").prop("hidden", true);
                $("#VencimientoCUDTitulo").prop("hidden", true);
                $("#NumeroCUDTitulo").prop("hidden", true);
                $("#NumeroCUDValidacion").addClass("ocultar");
                $("#VencimientoCudValidacion").addClass("ocultar");
            }
            $("#FechaInicioDiscapacidad").val(discapacitadomostrar.FechaInicioDiscapacidad);

            $("#FechaNacimientoConsultante").val(discapacitadomostrar.FechaNacimientoConsultante);
            $("#PersonaConDiscapacidadID").val(discapacitadomostrar.PersonaConDiscapacidadID);
            $("#Diagnostico").val(discapacitadomostrar.Diagnostico);
            $("#CudExistente").val(discapacitadomostrar.CudExistente);


            
            var Postrado = discapacitadomostrar.Postrado;
            if (Postrado == true) {
                $("#Postrado").val("true");
            } else {
                $("#Postrado").val("false");
            }
            $("#PencionPorincadiscapacitadomostrar.Postradopacidad").val(discapacitadomostrar.PencionPorincapacidad);

            var InicioDiscapacidadNacimiento = discapacitadomostrar.InicioDiscapacidadNacimiento;
            if (InicioDiscapacidadNacimiento === false) {
                $("#InicioDiscapacidadNacimiento").val("false");
                $("#div-Fechainiciodiscapacidad").removeClass("ocultar");
            } else {
                $("#InicioDiscapacidadNacimiento").val("true");
                $("#div-Fechainiciodiscapacidad").addClass("ocultar");
            }
            
            $("#Observaciones").val(discapacitadomostrar.Observaciones);
            $("#NombreConsultante").val(discapacitadomostrar.NombreConsultante);
            $("#DireccionConsultante").val(discapacitadomostrar.DireccionConsultante);
            $("#DniConsultante").val(discapacitadomostrar.DniConsultante);
            $("#TelefonoConsultante").val(discapacitadomostrar.TelefonoConsultante);
            $("#LocalidadConsultante").val(discapacitadomostrar.LocalidadConsultante);
            if (discapacitadomostrar.NombreConsultante != "") {
                $("#ExisteConsultante").val("true");
                $("#div-consultante").removeClass("ocultar");
                $("#div-niveleducativoconsultante").removeClass("ocultar");
            } else {
                $("#ExisteConsultante").val("false");
                $("#div-consultante").addClass("ocultar");
                $("#div-niveleducativoconsultante").addClass("ocultar");
            }


            var DiagnosticoEnfermedad = discapacitadomostrar.DiagnosticoEnfermedad;
            if (DiagnosticoEnfermedad == true) {
                $("#DiagnosticoEnfermedad").val("true");
                $("#DetalleDiagnosticoEnfermedad").prop("hidden", false);
                $("#CualDiagnostico").prop("hidden", false);
                $("#DetalleDiagnosticoEnfermedadValidacion").addClass("ocultar");
            } else {
                $("#DiagnosticoEnfermedad").val("false");
                $("#DetalleDiagnosticoEnfermedad").prop("hidden", true);
                $("#CualDiagnostico").prop("hidden", true);
            }
            $("#DetalleDiagnosticoEnfermedad").val(discapacitadomostrar.DetalleDiagnosticoEnfermedad);

            var TratamientoMedico = discapacitadomostrar.TratamientoMedico;
            if (TratamientoMedico == true) {
                $("#TratamientoMedico").val("true");
                $("#DetalleTratamientoMedico").prop("hidden", false);
                $("#LugarTratamientoMedico").prop("hidden", false);
                $("#cualTratamiento").prop("hidden", false);
                $("#DondeTratamiento").prop("hidden", false);
                $("#DetalleTratamientoMedicoValidacion").addClass("ocultar");
                $("#LugarTratamientoMedicoValidacion").addClass("ocultar");
            } else {
                $("#TratamientoMedico").val("false");
                $("#DetalleTratamientoMedico").prop("hidden", true);
                $("#cualTratamiento").prop("hidden", true);
                $("#DondeTratamiento").prop("hidden", true);
                $("#LugarTratamientoMedico").prop("hidden", true);
            }
            $("#DetalleTratamientoMedico").val(discapacitadomostrar.DetalleTratamientoMedico);
            $("#LugarTratamientoMedico").val(discapacitadomostrar.LugarTratamientoMedico);
            var InterrumpioTratamientoMedico = discapacitadomostrar.InterrumpioTratamientoMedico;
            if (InterrumpioTratamientoMedico == true) {
                $("#InterrumpioTratamientoMedico").val("true");
                $("#TiempoInterrupcionTratamientoMedico").prop("hidden", false);
                $("#MotivoInterrupcionTratamientoMedico").prop("hidden", false);
                $("#TiempoInterrupcionPregunta").prop("hidden", false);
                $("#MotivoInterrupcionPregunta").prop("hidden", false);
                $("#TiempoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
                $("#MotivoInterrupcionTratamientoMedicoValidacion").addClass("ocultar");
            } else {
                $("#InterrumpioTratamientoMedico").val("false");
                $("#TiempoInterrupcionTratamientoMedico").prop("hidden", true);
                $("#MotivoInterrupcionTratamientoMedico").prop("hidden", true);
                $("#TiempoInterrupcionPregunta").prop("hidden", true);
                $("#MotivoInterrupcionPregunta").prop("hidden", true);
            }
            $("#TiempoInterrupcionTratamientoMedico").val(discapacitadomostrar.TiempoInterrupcionTratamientoMedico);
            $("#MotivoInterrupcionTratamientoMedico").val(discapacitadomostrar.MotivoInterrupcionTratamientoMedico);
            var TrastornoSuenio = discapacitadomostrar.TrastornoSuenio;
            if (TrastornoSuenio == true) {
                $("#TrastornoSuenio").val("true");
            } else {
                $("#TrastornoSuenio").val("false");
            }

            var TrastornoAlimenticio = discapacitadomostrar.TrastornoAlimenticio;
            if (TrastornoAlimenticio == true) {
                $("#TrastornoAlimenticio").val("true");
            } else {
                $("#TrastornoAlimenticio").val("false");
            }

            var IngestaAnsioAntidepre = discapacitadomostrar.IngestaAnsioAntidepre;
            if (IngestaAnsioAntidepre == true) {
                $("#IngestaAnsioAntidepre").val("true");
            } else {
                $("#IngestaAnsioAntidepre").val("false");
            }

            var ConsumioAlcoholoDroga = discapacitadomostrar.ConsumioAlcoholoDroga;
            if (ConsumioAlcoholoDroga == true) {
                $("#ConsumioAlcoholoDroga").val("true");
            } else {
                $("#ConsumioAlcoholoDroga").val("false");
            }

            var OtrosTrastornos = discapacitadomostrar.OtrosTrastornos;
            if (OtrosTrastornos == true) {
                $("#OtrosTrastornos").val("true");
            } else {
                $("#OtrosTrastornos").val("false");
            }

            var AbortoPorGolpe = discapacitadomostrar.AbortoPorGolpe;
            if (AbortoPorGolpe == true) {
                $("#AbortoPorGolpe").val("true");
            } else {
                $("#AbortoPorGolpe").val("false");
            }

            var IntentoDeSuicidio = discapacitadomostrar.IntentoDeSuicidio;
            if (IntentoDeSuicidio == true) {
                $("#IntentoDeSuicidio").val("true");
            } else {
                $("#IntentoDeSuicidio").val("false");
            }

            var CuentaConParienteAQuienRecurir = discapacitadomostrar.CuentaConParienteAQuienRecurir;
            if (CuentaConParienteAQuienRecurir == true) {
                $("#CuentaConParienteAQuienRecurir").val("true");
                $("#AQueParienteRecurir").prop("hidden", false);
                $("#AQueParienteRecurirTitulo").prop("hidden", false);

            } else {
                $("#CuentaConParienteAQuienRecurir").val("false");
                $("#AQueParienteRecurir").prop("hidden", true);
                $("#AQueParienteRecurirTitulo").prop("hidden", true);
                $("#AQueParienteRecurirValidacion").addClass("ocultar");
            }
            $("#AQueParienteRecurir").val(discapacitadomostrar.AQueParienteRecurir);

            var CuentaConAmigosVecinosCompanieroTrabajo = discapacitadomostrar.CuentaConAmigosVecinosCompanieroTrabajo;
            if (CuentaConAmigosVecinosCompanieroTrabajo == true) {
                $("#CuentaConAmigosVecinosCompanieroTrabajo").val("true");
                $("#QueAmigosVecinosCompanieroTrabajo").prop("hidden", false);
                $("#QueAmigosVecinosCompanieroTrabajoTirulo").prop("hidden", false);
            } else {
                $("#CuentaConAmigosVecinosCompanieroTrabajo").val("false");
                $("#QueAmigosVecinosCompanieroTrabajo").prop("hidden", true);
                $("#QueAmigosVecinosCompanieroTrabajoTirulo").prop("hidden", true);
                $("#QueAmigosVecinosCompanieroTrabajoValidacion").addClass("ocultar");
            }
            $("#QueAmigosVecinosCompanieroTrabajo").val(discapacitadomostrar.QueAmigosVecinosCompanieroTrabajo);

            var AsisteAIntitucionComunitaria = discapacitadomostrar.AsisteAIntitucionComunitaria;
            if (AsisteAIntitucionComunitaria == true) {
                $("#AsisteAIntitucionComunitaria").val("true");
                $("#CualIntitucionComunitaria").prop("hidden", false);
                $("#CualIntitucionComunitariaTitulo").prop("hidden", false);
                $("#PersonaDeContactoIntitucionComunitaria").prop("hidden", false);
                $("#ConQuienSeContactaEnIntitucionComunitaria").prop("hidden", false);
            } else {
                $("#AsisteAIntitucionComunitaria").val("false");
                $("#CualIntitucionComunitaria").prop("hidden", true);
                $("#CualIntitucionComunitariaTitulo").prop("hidden", true);
                $("#PersonaDeContactoIntitucionComunitaria").prop("hidden", true);
                $("#ConQuienSeContactaEnIntitucionComunitaria").prop("hidden", true);
                $("#CualIntitucionComunitariaValidacion").addClass("ocultar");
                $("#ConQuienSeContactaEnIntitucionComunitariaValidacion").addClass("ocultar");
            }
            $("#CualIntitucionComunitaria").val(discapacitadomostrar.CualIntitucionComunitaria);
            $("#ConQuienSeContactaEnIntitucionComunitaria").val(discapacitadomostrar.ConQuienSeContactaEnIntitucionComunitaria);

            var DejoDeContactarAAlguien = discapacitadomostrar.DejoDeContactarAAlguien;
            if (DejoDeContactarAAlguien == true) {
                $("#DejoDeContactarAAlguien").val("true");
                $("#AQuienDejoDeContactar").prop("hidden", false);
                $("#AQuienDejoDeContactarTitulo").prop("hidden", false);
            } else {
                $("#DejoDeContactarAAlguien").val("false");
                $("#AQuienDejoDeContactar").prop("hidden", true);
                $("#AQuienDejoDeContactarTitulo").prop("hidden", true);
                $("#AQuienDejoDeContactarValidacion").addClass("ocultar");
            }
            $("#AQuienDejoDeContactar").val(discapacitadomostrar.AQuienDejoDeContactar);
            var VioleciaFisicaOPiscConsultante = discapacitadomostrar.VioleciaFisicaOPiscConsultante;
            if (VioleciaFisicaOPiscConsultante == true) {
                $("#VioleciaFisicaOPiscConsultante").val("true");
            } else {
                $("#VioleciaFisicaOPiscConsultante").val("false");
            }

            var ViolacionAbusoSexualConsultante = discapacitadomostrar.ViolacionAbusoSexualConsultante;
            if (ViolacionAbusoSexualConsultante == true) {
                $("#ViolacionAbusoSexualConsultante").val("true");
            } else {
                $("#ViolacionAbusoSexualConsultante").val("false");
            }

            var TestigoDeViolenciaConsultante = discapacitadomostrar.TestigoDeViolenciaConsultante;
            if (TestigoDeViolenciaConsultante == true) {
                $("#TestigoDeViolenciaConsultante").val("true");
            } else {
                $("#TestigoDeViolenciaConsultante").val("false");
            }

            var AbandonoConsultante = discapacitadomostrar.AbandonoConsultante;
            if (AbandonoConsultante == true) {
                $("#AbandonoConsultante").val("true");
            } else {
                $("#AbandonoConsultante").val("false");
            }

            var OtrasParejasConsultante = discapacitadomostrar.OtrasParejasConsultante;
            if (OtrasParejasConsultante == true) {
                $("#OtrasParejasConsultante").val("true");
            } else {
                $("#OtrasParejasConsultante").val("false");
            }

            $("#OtraViolenciaConsultante").val(discapacitadomostrar.OtraViolenciaConsultante);
            if (discapacitadomostrar.OtraViolenciaConsultante == null) {
                $("#SeleccionOtrosConsultante").val("false");
                $("#CualOtraViolenciaConsultante").addClass("ocultar");
            }
            else {
                $("#SeleccionOtrosConsultante").val("true");
                $("#CualOtraViolenciaConsultante").removeClass("ocultar");
            }

            var VioleciaFisicaOPiscDiscapacitado = discapacitadomostrar.VioleciaFisicaOPiscDiscapacitado;

            if (VioleciaFisicaOPiscDiscapacitado == true) {
                $("#VioleciaFisicaOPiscDiscapacitado").val("true");
            } else {
                $("#VioleciaFisicaOPiscDiscapacitado").val("false");
            }



            var ViolacionAbusoSexualDiscapacitado = discapacitadomostrar.ViolacionAbusoSexualDiscapacitado;
            if (ViolacionAbusoSexualDiscapacitado == true) {
                $("#ViolacionAbusoSexualDiscapacitado").val("true");
            } else {
                $("#ViolacionAbusoSexualDiscapacitado").val("false");
            }

            var TestigoDeViolenciaDiscapacitado = discapacitadomostrar.TestigoDeViolenciaDiscapacitado;
            if (TestigoDeViolenciaDiscapacitado == true) {
                $("#TestigoDeViolenciaDiscapacitado").val("true");
            } else {
                $("#TestigoDeViolenciaDiscapacitado").val("false");
            }

            var AbandonoDiscapacitado = discapacitadomostrar.AbandonoDiscapacitado;
            if (AbandonoDiscapacitado == true) {
                $("#AbandonoDiscapacitado").val("true");
            } else {
                $("#AbandonoDiscapacitado").val("false");
            }

            var OtrasParejasDiscapacitado = discapacitadomostrar.OtrasParejasDiscapacitado;
            if (OtrasParejasDiscapacitado == true) {
                $("#OtrasParejasDiscapacitado").val("true");
            } else {
                $("#OtrasParejasDiscapacitado").val("false");
            }

            var IgnoradoDiscapacitado = discapacitadomostrar.IgnoradoDiscapacitado;
            if (IgnoradoDiscapacitado == true) {
                $("#IgnoradoDiscapacitado").val("true");
            } else {
                $("#IgnoradoDiscapacitado").val("false");
            }
            $("#OtraViolenciaDiscapacitado").val(discapacitadomostrar.OtraViolenciaDiscapacitado);
            if (discapacitadomostrar.OtraViolenciaDiscapacitado == null) {
                $("#SeleccionOtrosDiscapacitado").val("false");
                $("#CualOtraViolenciaDiscapacitado").addClass("ocultar");
            } else {
                $("#SeleccionOtrosDiscapacitado").val("true");
                $("#CualOtraViolenciaDiscapacitado").removeClass("ocultar");
            }

            $("#NivelEducativoIDConsultante").val(discapacitadomostrar.NivelEducativoIDConsultante);
            $("#NivelEducativoIDDiscapacitado").val(discapacitadomostrar.NivelEducativoIDDiscapacitado);



            $("#SituacionObreroConsultante").prop("checked", false);
            $("#SituacionObreroDiscapacitado").prop("checked", false);
            $("#SituacionEmpresarioConsultante").prop("checked", false);
            $("#SituacionEmpresarioDiscapacitado").prop("checked", false);
            $("#SituacionEmpleadoConsultante").prop("checked", false);
            $("#SituacionEmpleadoDiscapacitado").prop("checked", false);
            $("#SituacionJubiladoConsultante").prop("checked", false);
            $("#SituacionJubiladoDiscapacitado").prop("checked", false);
            $("#SituacionNoTrabajaConsultante").prop("checked", false);
            $("#SituacionNoTrabajaDiscapacitado").prop("checked", false);
            $("#SituacionProfesionalDiscapacitado").prop("checked", false);
            $("#SituacionProfesionalConsultante").prop("checked", false);
            $("#SituacionServicioDomesticoConsultante").prop("checked", false);
            $("#SituacionServicioDomesticoDiscapacitado").prop("checked", false);





            if (discapacitadomostrar.SituacionObreroConsultante == true) {
                $("#SituacionObreroConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionObreroDiscapacitado == true) {
                $("#SituacionObreroDiscapacitado").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionEmpresarioConsultante == true) {
                $("#SituacionEmpresarioConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionEmpresarioDiscapacitado == true) {
                $("#SituacionEmpresarioDiscapacitado").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionEmpleadoConsultante == true) {
                $("#SituacionEmpleadoConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionEmpleadoDiscapacitado == true) {
                $("#SituacionEmpleadoDiscapacitado").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionJubiladoConsultante == true) {
                $("#SituacionJubiladoConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionJubiladoDiscapacitado == true) {
                $("#SituacionJubiladoDiscapacitado").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionNoTrabajaConsultante == true) {
                $("#SituacionNoTrabajaConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionNoTrabajaDiscapacitado == true) {
                $("#SituacionNoTrabajaDiscapacitado").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionProfesionalDiscapacitado == true) {
                $("#SituacionProfesionalDiscapacitado").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionProfesionalConsultante == true) {
                $("#SituacionProfesionalConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionServicioDomesticoConsultante == true) {
                $("#SituacionServicioDomesticoConsultante").prop("checked", true);
            }
            if (discapacitadomostrar.SituacionServicioDomesticoDiscapacitado == true) {
                $("#SituacionServicioDomesticoDiscapacitado").prop("checked", true);
            }

            $("#IngresosFamiliarLaboral").val(discapacitadomostrar.IngresosFamiliarLaboral);


            $("#TipodeDiscapacidadID").val(discapacitadomostrar.TipodeDiscapacidad.TipodeDiscapacidadID);

            $("#AccesibilidadAlServicioID").val(discapacitadomostrar.AccesibilidadAlServicio.AccesibilidadAlServicioID);

            $("#PersonaNombre").val(discapacitadomostrar.Persona.PersonaApellidoNombre);
            $("#PersonaFechaNacimiento").val(discapacitadomostrar.Persona.PersonaFechaNacimientoString);
            $("#PersonaDNI").val(discapacitadomostrar.Persona.PersonaDNI);
            $("#PersonaDomicilio").val(discapacitadomostrar.Persona.PersonaDireccion);
            $("#PersonaTelefono").val(discapacitadomostrar.Persona.PersonaTelefono);
            $("#Obrasocialcual").val(discapacitadomostrar.Persona.ObraSocialCual);
            if (discapacitadomostrar.Persona.PersonaObraSocial === true) {
                $("#Obrasocialsino").val("Sí");
            }
            else {
                $("#Obrasocialsino").val("No");
            }

        },
        error: function (data) {

        }
    });
}


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


//funcion utilizada para traer las selecciones realizadas al crear en situacion habitacional
function SituacionHabitacionalDetalle(ID) {
    var NumeroId = ID;
    var sectorvista = "";
    var situacion = "";
    var observacion = "";
    var ubicacionObservacion = "";
    var observacionCaracteristicas = "";
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/SituacionHabitacionalDetalle',
        data: { PersonaCondiscapacidadID: NumeroId },
        success: function (listadodecaracteristicasmostrar) {

            $.each(listadodecaracteristicasmostrar, function (index, listadodecaracteristicas) {
                //cargo en las variables antes declarada los diferentes valores para un codigo mas limpio
                ubicacionObservacion = "#Observacion_" + listadodecaracteristicas.SituacionHabitacionalID;
                sectorvista = "Sector_" + listadodecaracteristicas.SectorSeleccionado;
                situacion = listadodecaracteristicas.SituacionHabitacionalID;
                observacion = listadodecaracteristicas.Observacion;
                observacionCaracteristicas = listadodecaracteristicas.ObservacionString;
                //busco el input seleccionado cuando se creo la persona con discapacidad, con el name del input y su valor
                //y le pongo la propiedad de cheked para seleccionarlo
                $("input[name=" + sectorvista + "][value= " + situacion + "]").prop("checked", true);
                $("input[name=" + sectorvista + "][value= " + situacion + "]").prop("disabled", false);
                //acontinuacion controlo que si hay un campo de observacion y esta activo me cargue el dato en ese campo de observacion, en estos casos el el monto del alquier
                if (observacion == true) {
                    $(ubicacionObservacion).val(observacionCaracteristicas);
                    $(ubicacionObservacion).prop("disabled", false);
                }
            });
        },
        error: function (data) {

            alert("Problemas al tratar de enviar el formulario");
        }
    });

}

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
//funcion para limpiar todo el formulario de grupo familiar de la vista parcial de crear grupo familiar
function LimpiarFormularioGrupoFamiliar(origen) {
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
                        '<img src="../../Content/dashtreme-master/assets/images/iconos menu/editar.png" class="icono-tabla" data-toggle="modal" data-target="#ModalCrearGrupoFamiliar"/>' +
                        '</a>' +
                        '<td class="text-center TextoNegroTablas tdBotones ContenidoTablaGris  ">' +
                        '<a id="botonEliminarGrupoFamiliar" class="btn-circle-index" onclick="EliminarGrupoFamiliar(' + grupofamiliar.GrupoFamiliarID + ');"><img src="../../Content/dashtreme-master/assets/images/iconos menu/basura.png" class="icono-tabla" /></a>' +
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

    if (grupoFamiliarNacimiento == FechaPredeterminada || grupoFamiliarNacimiento == null || grupoFamiliarNacimiento < FechaPredeterminada || grupoFamiliarNacimiento > FechaHoy) {
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
                    LimpiarFormularioGrupoFamiliar();
                    $('#ModalCrearGrupoFamiliar').modal('hide');
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
    $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", true);
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
    var guardarValidacion = true;



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
        guardarValidacion = false;
    }

    //Validacion cuando selecciona que si completa la planilla un consultante
    if (existeConsultante == 'true') {
        if (nombreConsultante == '') {
            $("#NombreConsultanteValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
        if (fechaNacimientoConsultante == FechaPredeterminada || fechaNacimientoConsultante == null || fechaNacimientoConsultante < FechaPredeterminada || fechaNacimientoConsultante > FechaHoy) {
            $("#FechaNacimientoConsultanteValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
        if (dniConsultante == 0) {
            guardarValidacion = false;
            $("#DniConsultanteValidacion").removeClass("ocultar");
        }
    }

    //Validacion cuando selecciona que tiene un CUD.
    if (cudExistente == 1) {
        if (numeroCUD == '' || numeroCUD == null || numeroCUD == 0) {
            $("#NumeroCUDValidacion").removeClass("ocultar");
            guardarValidacion = false;

        }
        if (vencimientoCud == FechaPredeterminada || vencimientoCud < FechaPredeterminada || vencimientoCud == null) {
            $("#VencimientoCudValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
    }

    //Validacion Cuando seleccionan que la discapacidad fue adquirida
    if (inicioDiscapacidadNacimiento == 'false') {
        if (fechaInicioDiscapacidad < FechaPredeterminada || fechaInicioDiscapacidad == null || fechaInicioDiscapacidad == FechaPredeterminada || fechaInicioDiscapacidad > FechaHoy) {
            $("#FechaInicioDiscapacidadValidacion").removeClass("ocultar");

            guardarValidacion = false;
        }
    }

    //Validacion cuando se selecciona que tiene un diagnostico de enfermedad.
    if (diagnosticoEnfermedad == 'true') {
        if (detalleDiagnosticoEnfermedad == '') {
            $("#DetalleDiagnosticoEnfermedadValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
    }

    //Validacion cuando se selecciona que actualmente esta realizando un tratamiento medico.
    if (tratamientoMedico == 'true') {
        if (detalleTratamientoMedico == '') {
            $("#DetalleTratamientoMedicoValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
        if (lugarTratamientoMedico == '') {
            $("#LugarTratamientoMedicoValidacion").removeClass("ocultar");
            guardarValidacion = false;
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


    //Validacion cuando se selecciona que actualmente esta realizando un tratamiento medico.
    if (interrumpioTratamientoMedico == 'true') {
        if (tiempoInterrupcionTratamientoMedico == "") {
            $("#TiempoInterrupcionTratamientoMedicoValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
        if (motivoInterrupcionTratamientoMedico == "") {
            $("#MotivoInterrupcionTratamientoMedicoValidacion").removeClass("ocultar");
            guardarValidacion = false;
        }
    }
    if (guardarValidacion === true ) {

        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'La Persona Con Discapacidad se Guardo Correctamente',
            showConfirmButton: false,
            timer: 3000
        })

        document.getElementById("BotonGuardarDiscapacitado").click();
        $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
    } else {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Complete todo los campos',
            showConfirmButton: false,
            timer: 1000
        })
        $("#Boton-Guardar-PersonaConDiscapaciad").prop("disabled", false);
    }
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
                        '<img src="../../Content/dashtreme-master/assets/images/iconos menu/editar.png" class="icono-tabla" data-toggle="modal" data-target="#ModalCrearRelacionInstitutoYPersona"/>' +
                        '</a>' + '</td>' +
                        '<td class="text-center TextoNegroTablas tdBotones ContenidoTablaGris">' +
                        '<a id="botonEliminarRelacionEscuelaconPersona" class="btn-circle-index " onclick="EliminarRelacionEscuelaYPersona(' + relacion.RelacionInstitutoYPersonaID + ');"><img src="../../Content/dashtreme-master/assets/images/iconos menu/basura.png" class="icono-tabla" /></a>' +
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

$("#ExisteConsultante").change(function () {
    if ($(this).val() === "true") {
        $("#div-consultante").removeClass("ocultar");
        $("#div-niveleducativoconsultante").removeClass("ocultar");
    } else {
        $("#div-consultante").addClass("ocultar");
        $("#div-niveleducativoconsultante").addClass("ocultar");
    }
});


$("#CudExistente").change(function () {
    if ($(this).val() === "1") {
        $("#NumeroCUD").prop("hidden", false);
        $("#VencimientoCud").prop("hidden", false);
        $("#VencimientoCUDTitulo").prop("hidden", false);
        $("#NumeroCUDTitulo").prop("hidden", false);
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

$("#DiagnosticoEnfermedad").change(function () {
    if ($(this).val() === "false") {
        $("#DetalleDiagnosticoEnfermedad").prop("hidden", true);
        $("#CualDiagnostico").prop("hidden", true);
    } else {
        $("#DetalleDiagnosticoEnfermedad").prop("hidden", false);
        $("#CualDiagnostico").prop("hidden", false);
        $("#DetalleDiagnosticoEnfermedadValidacion").addClass("ocultar");

    }
});
