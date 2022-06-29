// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

indexador();



















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