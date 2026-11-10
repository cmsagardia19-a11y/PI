namespace Datos
{
    public interface ILoginRepositorio
    {
        bool ValidarCredenciales(
            string usuario,
            string contrasena,
            out int codUsu,
            out string nombre,
            out string apellido,
            out int rol);
    }
}