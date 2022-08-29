namespace Software
{
    public class Cliente
    {
        public Cliente(int Cuit, string RazonSocial)
        {
            this.Cuit = Cuit;
            this.RazonSocial = RazonSocial;
        }

        public int Cuit { get; set; }

        public string RazonSocial { get; set; }
    }
}