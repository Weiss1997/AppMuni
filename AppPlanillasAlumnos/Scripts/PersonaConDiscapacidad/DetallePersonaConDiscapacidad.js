
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
            if (true) {
                $("#FechaInicioDiscapacidad").prop("hidden", false);
                $("#FechaInicioDiscapacidadTitulo").prop("hidden", false);
            } else {
                $("#FechaInicioDiscapacidad").prop("hidden", true);
                $("#FechaInicioDiscapacidadTitulo").prop("hidden", true);
                $("#FechaInicioDiscapacidadValidacion").addClass("ocultar");
            }
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
            if (InicioDiscapacidadNacimiento == true) {
                $("#InicioDiscapacidadNacimiento").val("true");
                $("#FechaInicioDiscapacidad").prop("hidden", true);
                $("#FechaInicioDiscapacidadTitulo").prop("hidden", true);
                $("#FechaInicioDiscapacidadValidacion").addClass("ocultar");
            } else {
                $("#InicioDiscapacidadNacimiento").val("false");
                $("#FechaInicioDiscapacidad").prop("hidden", false);
                $("#FechaInicioDiscapacidadTitulo").prop("hidden", false);
            }
            $("#Observaciones").val(discapacitadomostrar.Observaciones);
            $("#NombreConsultante").val(discapacitadomostrar.NombreConsultante);
            $("#DireccionConsultante").val(discapacitadomostrar.DireccionConsultante);
            $("#DniConsultante").val(discapacitadomostrar.DniConsultante);
            $("#TelefonoConsultante").val(discapacitadomostrar.TelefonoConsultante);
            $("#LocalidadConsultante").val(discapacitadomostrar.LocalidadConsultante);
            if ($("#NombreConsultante").val() != "") {
                $("#NombreConsultante").prop("hidden", false);
                $("#DireccionConsultante").prop("hidden", false);
                $("#LocalidadConsultante").prop("hidden", false);
                $("#TelefonoConsultante").prop("hidden", false);
                $("#DniConsultante").prop("hidden", false);
                $("#FechaNacimientoConsultante").prop("hidden", false);
                $("#NombreConsultanteTitulo").prop("hidden", false);
                $("#DireccionConsultanteTitulo").prop("hidden", false);
                $("#LocalidadConsultanteTitulo").prop("hidden", false);
                $("#TelefonoConsultanteTitulo").prop("hidden", false);
                $("#DniConsultanteTitulo").prop("hidden", false);
                $("#FechaNacimientoConsultanteTitulo").prop("hidden", false);
                $("#NivelEducativoIDConsultante").prop("hidden", false);
                $("#NivelEducativoIDConsultanteTitulo").prop("hidden", false);
            } else {
                $("#NombreConsultante").prop("hidden", true);
                $("#DireccionConsultante").prop("hidden", true);
                $("#LocalidadConsultante").prop("hidden", true);
                $("#TelefonoConsultante").prop("hidden", true);
                $("#DniConsultante").prop("hidden", true);
                $("#FechaNacimientoConsultante").prop("hidden", true);
                $("#NombreConsultanteTitulo").prop("hidden", true);
                $("#DireccionConsultanteTitulo").prop("hidden", true);
                $("#LocalidadConsultanteTitulo").prop("hidden", true);
                $("#TelefonoConsultanteTitulo").prop("hidden", true);
                $("#DniConsultanteTitulo").prop("hidden", true);
                $("#FechaNacimientoConsultanteTitulo").prop("hidden", true);
                $("#NivelEducativoIDConsultante").prop("hidden", true);
                $("#NivelEducativoIDConsultanteTitulo").prop("hidden", true);
                $("#NombreConsultanteValidacion").addClass("ocultar");
                $("#FechaNacimientoConsultanteValidacion").addClass("ocultar");
                $("#DniConsultanteValidacion").addClass("ocultar");
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
            $("#NivelEducativoIDConsultante").val(discapacitadomostrar.NivelEducativoConsultanteString);
            $("#NivelEducativoIDDiscapacitado").val(discapacitadomostrar.NivelEducativoDiscapacitadoString);



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


            $("#TipodeDiscapacidadID").val(discapacitadomostrar.TipodeDiscapacidad.NombredelaDiscapacidad);

            $("#AccesibilidadAlServicioID").val(discapacitadomostrar.AccesibilidadAlServicio.AccesibilidadDescripcion);

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

//funcion para buscar el listado de las escuelas que asiste la persona seleccionada
function BuscarListadoEscuelaPorPersona(personaID) {
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/BuscarListadoEscuelaPorPersona',
        data: { PersonaID: personaID },
        success: function (RelacionesInstitutoYPersonaMostrar) {
            $("#tbody-RelacionInstitutoYPersona").empty();
            $.each(RelacionesInstitutoYPersonaMostrar, function (index, relacion) {
                $("#tbody-RelacionInstitutoYPersona").append('<tr>' +
                    '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + relacion.Escuela.EscuelaNombre + '</td>' +
                    '</tr>'
                );
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
//funcion para buscar el listado del grupo familiar de la persona seleccionada
function BuscarGrupoFamiliar(personaID) {
    $("#tbody-GrupoFamiliar").empty();
    $.ajax({
        type: "POST",
        url: '../../PersonaConDiscapacidads/BuscarGrupoFamiliar',
        data: { PersonaID: personaID },
        success: function (grupofamiliaresmostrar) {
            /*
            * Se ejecuta cuando termina la petición y esta ha sido
            * correcta
            * */

            $("#tbody-GrupoFamiliar").empty();

            $.each(grupofamiliaresmostrar, function (index, grupofamiliar) {
                $("#tbody-GrupoFamiliar").append('<tr>' +
                    '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarApellidoNombre + '</td>' +
                    '<td class="text-left TextoNegroTablas ocultar860 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarNacimientoString + '</td>' +
                    '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarSexoString + '</td>' +
                    '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarVinculo + '</td>' +
                    '<td class="text-left TextoNegroTablas ocultar1430 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarEscolaridad + '</td>' +
                    '<td class="text-left TextoNegroTablas ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarDNI + '</td>' +
                    '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarOcupacion + '</td>' +
                    '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarSalud + '</td>' +
                    '<td class="text-left TextoNegroTablas ocultar1120 ContenidoTablaGris">' + grupofamiliar.GrupoFamiliarIngresos + '</td>' +
                    + '</tr>'
                );
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




//funcion para traer toda la platilla de situacion habitacional
function BuscarSituacionesHabitacionales(ID) {
    var id = ID;
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
                $("#SituacionesHabitacionales").append('<div class="col-md-12 text-left RenglonGris">' + '<label class="control-label TextoNegroFormulario TextonegroCelu">' + '<u>' + "  " +
                    sectorVivienda.NombreSectorVivienda + '</u>' + '</label>' +
                    '<input type="hidden" name="SectoresViviendasID" value="' + sectorVivienda.SectorViviendaID + '"> ' +
                    '</div>');

                $.each(sectorVivienda.Caracteristicas, function (index, caracteristica) {

                    ubicacionCaract += 1;

                    var liniaInput = '<input type="Radio" class = "RadioNuevo" disabled id="' + sectorVivienda.SectorViviendaID + '" name="Sector_' + sectorVivienda.SectorViviendaID + '" value="' + caracteristica.SituacionHabitacionalID + '">';

                    var lineaInputObservacion = "";
                    if (caracteristica.Observacion == true) {
                        lineaInputObservacion = '<input type="text" class="form-control form-control-rounded" disabled name="Observacion_' + caracteristica.SituacionHabitacionalID + '" id="Observacion_' + caracteristica.SituacionHabitacionalID + '">';
                    }

                    $("#SituacionesHabitacionales").append(
                        '<div class="col-md-3">' + '<label class="TextoNegroFormulario TextonegroCelu">' + liniaInput + ' ' + caracteristica.NombreCaracteristicaSector + '</label>' +
                        lineaInputObservacion +
                        '</div>'
                    );
                });

                ubicacionCaract = 0;
            });
            SituacionHabitacionalDetalle(id);

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
                }
            });
        },
        error: function (data) {

            alert("Problemas al tratar de enviar el formulario");
        }
    });

}
