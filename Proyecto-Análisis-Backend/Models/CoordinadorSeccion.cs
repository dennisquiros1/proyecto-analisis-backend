using System;
using System.Collections.Generic;

namespace Proyecto_Análisis_Backend.Models;

public partial class CoordinadorSeccion
{
    public string Usuario { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? GradoAcademico { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
}
