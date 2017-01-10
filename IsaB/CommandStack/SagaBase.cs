namespace IsaB.CommandStack
{
    public class SagaBase<T>
    {
        public string ID { get; set; }
        public T Data { get; set; }
    }
}
