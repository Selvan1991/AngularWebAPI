namespace StudentDetail.Response
{
    /// <summary>
    /// Generic application response model 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApplicationResponse<T>
    {
        public T Data { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
