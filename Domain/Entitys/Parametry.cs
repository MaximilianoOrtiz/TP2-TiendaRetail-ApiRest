namespace Domain.Entitys
{
    //Se crea esta Clase para evitar tener valor harcodeados en el codigo y facilitar su actualizacion y mantenimiento
    public class Parametry
    {
        public int ParametriaId { get; set; }
        public string Codigo { get; set; }
        public decimal Value { get; set; } 

        public Parametry(int parametriaId, string codigo, decimal value)
        {
            ParametriaId = parametriaId;
            Codigo = codigo;
            Value = value;
        }
    }
}
