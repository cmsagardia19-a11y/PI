namespace Datos
{
    public interface IUsuarioRepositorio
    {
        (int CodUsu, int NroSocio) RegistrarSocio(
            string nombre,
            string apellido,
            string dni,
            bool aptoMedico);
    }
}
