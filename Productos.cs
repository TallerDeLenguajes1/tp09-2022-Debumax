public class Productos 
{
    private string? nombre;
    private DateTime fechaVencimiento;
    private float precio;//1000-5000
    private string? tamanio;
    private int id;
    
    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
    public float Precio { get => precio; set => precio = value; }
    public string? Tamanio { get => tamanio; set => tamanio = value; }

    public Productos(){}
    

    public Productos(int i)
    { 
        string [] nombres = {"tomate","leche","pan","condimento","arroz","bebida","golosinas"};
        string [] tamanios={"grande","mediano","chico"};    
        Random rand=new Random();
        Id=i;
        Nombre=nombres[rand.Next(0,7)];
        FechaVencimiento=new DateTime(rand.Next(2021,2023) , rand.Next(1,12) , rand.Next(1,31));
        Precio=rand.Next(1000,5001);
        Tamanio=tamanios[rand.Next(0,3)];
             
    }

    public void MostrarProducto(){
        Console.WriteLine($"Ide: {Id}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Fecha de Vencimiento: {FechaVencimiento}");
        Console.WriteLine($"Precio: {Precio}");
        Console.WriteLine($"Tamanio: {Tamanio}");
        
    }


}

