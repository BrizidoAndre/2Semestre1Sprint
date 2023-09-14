namespace webapi.inlock.codeFirst.manha.Utils
{
    public class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a hash</param>
        /// <returns></returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada é igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuário</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>True or False (se a senha for verdadeira)</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
