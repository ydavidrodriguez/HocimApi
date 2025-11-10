namespace Holcim.Application.DataBase.Usuario.Commands.Create
{
    public interface ICreateEmailForgetPasswordByEmail
    {
        object Execute(string correo);
    }
}
