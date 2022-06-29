// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Text.Json;

Console.WriteLine("Hello, World!");

//indexador();


//Productos pr=new Productos();
//pr.MostrarProducto();

List<Productos> listaProductos =new List<Productos>();

listaProductos=GeneraLista(listaProductos );
muestraProductos();

guardaProductosJson(listaProductos);
leerArchivoJson();






string CreaStringJson(List<Productos> listado){
    string textJson = JsonSerializer.Serialize(listado);// pasamos a json
    return textJson;    
}
void guardaProductosJson(List<Productos> listado){

    string ProdJson= CreaStringJson(listado);
    FileStream mijson= new FileStream("Productos.json",FileMode.Create);
    using (StreamWriter sw = new StreamWriter(mijson))
    {
        sw.WriteLine(ProdJson);//escribo la lista en el archivo
        sw.Close();
    }
}
void leerArchivoJson(){
    string archivoJson;

    using ( FileStream openArchivoJson= new FileStream("Productos.json",FileMode.Open)) // abro el archivo 
    {
        using (StreamReader sreader= new StreamReader(openArchivoJson))// lo convierto en algo
        {
            archivoJson= sreader.ReadToEnd(); // lo copio en el archivo ya 
            openArchivoJson.Close();
        }
    }
    List<Productos> listaDelJson = JsonSerializer.Deserialize<List<Productos>>(archivoJson); // lo convierto en la lista de productos
    
    Console.WriteLine("\n aqui listando lo de la lista (?)");
    foreach (Productos item in listaDelJson)
    {
        item.MostrarProducto();
    }        

}




void muestraProductos(){
    int i=1;
    foreach (Productos pro in listaProductos)
{
    Console.WriteLine($"producto n° {i}");
    Console.WriteLine("");
    pro.MostrarProducto();
    i++;
}
}

List<Productos> GeneraLista(List<Productos>  ListaProductos){
    
    Random rand = new Random();
    int nproductos=rand.Next(1,10);

    for (int i = 0; i < nproductos; i++)
    {
        Productos pr=new Productos(i);
        ListaProductos.Add(pr);
    }
    
    return ListaProductos;
}





// -----   FUNCIONES-------- 

void indexador(){
string rutaCarpeta=@"..\tp09-2022-Debumax";

List<string> listaDeContenido=Directory.GetFiles(rutaCarpeta).ToList();
Console.WriteLine($"la ruta es : {rutaCarpeta}");
foreach (string archivos in listaDeContenido)
{
 
    Console.WriteLine(archivos);
}

string archivo = rutaCarpeta+@"\index.json";
if (!File.Exists(archivo))
{
    File.Create(archivo);
}
Console.WriteLine("leyendo el archivo");

string texto=File.ReadAllText(archivo);
Console.WriteLine($"lo que contiene el archivo {texto} ");



Console.WriteLine("escribiendo el archivo");
File.WriteAllLines(archivo,listaDeContenido);
Console.WriteLine("fin de escritura");

Console.WriteLine("escribiendo como me piden");
int i=1;

//usando esta cosa para escribir en el archivo de forma mas bonita 
using (StreamWriter sw = new StreamWriter(archivo) )
{
    foreach (var elemento in listaDeContenido )
    {
        sw.WriteLine($"{i};{Path.GetFileNameWithoutExtension(archivo)};{Path.GetExtension(archivo)}");
        i++;
    }
    //tiene que ser con ";" para que este bien construido el archivo csv 
    sw.Close();
}

}