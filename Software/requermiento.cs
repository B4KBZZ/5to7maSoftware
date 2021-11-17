namespace Software
{
    public class Requermiento
    {
        public int Id { get; set; }

        public proyecto Proyecto { get; set; }

        public tecnologia Tecnologia { get; set; }

        public string Descripcion { get; set; }

        public int Complejidad  { get; set; }
    }
}