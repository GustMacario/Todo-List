namespace ToDoList.Utils
{
    public class ResponseUtil
    {
        public ResponseUtil()
        {
            Sucesso = false;
            Resultado = string.Empty;
        }

        public bool Sucesso { get; set; }
        public object Resultado { get; set; }
    }
}
