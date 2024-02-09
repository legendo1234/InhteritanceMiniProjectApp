namespace InheritanceMiniProject
{
    public interface IRentable : IInventoryitem 
    {
        void Rent();
        void ReturnRental();
    }
}
