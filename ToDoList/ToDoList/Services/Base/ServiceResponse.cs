namespace ToDoList.Services.Base
{
    public class ServiceResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        public ServiceResponse(T responseObject)
        {
            Success = true;
            Message = "Success";
            Data = responseObject;
        }

        public ServiceResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
            Data = default;
        }
    }
}
