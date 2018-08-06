using NearFriends.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnovaTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            int LoopPrograma = 0;
            List<Friend> listaAmigos = new List<Friend>();
            FriendApp amigoApp = new FriendApp();
            while (LoopPrograma >= 0)
            {
                Console.Clear();
                Console.WriteLine("Teste Técnico CNOVA - Amigos \r\n");               
                Console.WriteLine("Menu \r\n");
                Console.WriteLine("1 Cadastrar amigo");
                Console.WriteLine("2 Sair \r\n");
                
                if (listaAmigos.Count > 0)
                {
                    amigoApp.CalcularDistancia(listaAmigos);
                    ListarAmigos(listaAmigos);
                }

                bool escolhaValida = int.TryParse(Console.ReadLine(), out int Escolha);

                if (Escolha == 1)
                {
                    Console.WriteLine("\r\nDigite o nome do seu amigo.");
                    string nomeAmigo = Console.ReadLine();
                    Console.WriteLine("Digite a latitude do "+ nomeAmigo +".");

                    double latitudeAmigo = 0, longitudeAmigo = 0;
                    string latitude = Console.ReadLine();

                    Console.WriteLine("Digite a longitude do " + nomeAmigo + ".");
                    string longitude = Console.ReadLine();


                    bool validarDistancias = amigoApp.ValidarLatitudeLongitude(latitude, longitude);
                    
                    if (validarDistancias == true)
                    {
                        latitudeAmigo = Convert.ToDouble(latitude);
                        longitudeAmigo = Convert.ToDouble(longitude);

                            
                        if (listaAmigos.FirstOrDefault(t => t.Latitude == latitudeAmigo && t.Longitude == longitudeAmigo) == null)
                            listaAmigos.Add(new Friend { Nome = nomeAmigo, Latitude = latitudeAmigo, Longitude = longitudeAmigo });
                    }
                }
                else if (Escolha == 2)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida!");
                    Console.ReadLine();
                }
                LoopPrograma++;
            }
        }

        private static void ListarAmigos(List<Friend> listaAmigos)
        {
            Console.WriteLine("\r\n ##########  Lista de Amigos  ##########");

            int posicao = 1;
            foreach (var item in listaAmigos)
            {
                string amigo = " " + posicao.ToString() + " - " + item.Nome;
                if (item.AmigosProximos != null)
                {
                    if (item.AmigosProximos.Count > 0)
                    {
                        amigo += " - Amigos Próximos: ";
                        foreach (var amigosProximos in item.AmigosProximos)
                        {
                            amigo += amigosProximos.Nome;
                            if (item.AmigosProximos.IndexOf(amigosProximos) != item.AmigosProximos.Count - 1)
                            {
                                amigo += ",";
                            }
                        }
                    }                    
                }
                Console.WriteLine(amigo);
                posicao++;
            }
            Console.WriteLine("\r\n ##########  "+listaAmigos.Count+" amigo(s) cadastrados ##########");
            Console.WriteLine("\r\n Digite a opção do menu. \r\n");
        }
        

    }
}
