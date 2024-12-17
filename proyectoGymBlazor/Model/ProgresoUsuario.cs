

namespace proyectoGymBlazor.Model;
public class ProgresoUsuario
{
    public int ProgresoID { get; set; }
    public int UsuarioID { get; set; }
    public DateTime Fecha { get; set; }
    public string Metrica { get; set; }
    public decimal Valor { get; set; }

    public Usuario Usuario { get; set; }
} 

