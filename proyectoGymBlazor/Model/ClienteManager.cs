using Model.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;

public static class ClienteManager
{
    public static List<Cliente> ListaClientes { get; set; } = new List<Cliente>();
    private const string archivoClientes = "clientes.json";

    public static void GuardarClientes()
    {
        try
        {
            string json = JsonConvert.SerializeObject(ListaClientes, Formatting.Indented);
            File.WriteAllText(archivoClientes, json);
        }
        catch (Exception ex)
        {
            // Si no puedes usar MessageBox, utiliza Console.WriteLine para mensajes de error
            Console.WriteLine($"Error al guardar los clientes: {ex.Message}");
        }
    }

    public static void CargarClientes()
    {
        try
        {
            if (File.Exists(archivoClientes))
            {
                string json = File.ReadAllText(archivoClientes);
                ListaClientes = JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
            }
        }
        catch (Exception ex)
        {
            // Alternativa si no se puede usar MessageBox
            Console.WriteLine($"Error al cargar los clientes: {ex.Message}");
        }
    }
}

