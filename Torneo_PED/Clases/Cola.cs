using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class Cola<T>
    {
        private readonly LinkedList<T> _elementos = new LinkedList<T>();
        private readonly int _capacidadMaxima;

        public Cola(int capacidadMaxima = int.MaxValue)
        {
            _capacidadMaxima = capacidadMaxima;
        }

        public int Count => _elementos.Count;
        public bool EstaVacia => _elementos.Count == 0;
        public bool EstaLlena => _elementos.Count >= _capacidadMaxima;

        public void Encolar(T elemento)
        {
            if (EstaLlena)
            {
                throw new InvalidOperationException("La cola ha alcanzado su capacidad máxima");
            }
            _elementos.AddLast(elemento);
        }

        public T Desencolar()
        {
            if (EstaVacia)
            {
                throw new InvalidOperationException("La cola está vacía");
            }

            T elemento = _elementos.First.Value;
            _elementos.RemoveFirst();
            return elemento;
        }

        public List<T> ObtenerElementos()
        {
            return _elementos.ToList();
        }

        public void Limpiar()
        {
            _elementos.Clear();
        }

        public bool Contiene(T elemento)
        {
            return _elementos.Contains(elemento);
        }

        // Nuevo método para ver el primer elemento sin desencolar
        public T PrimerElemento()
        {
            if (EstaVacia)
            {
                throw new InvalidOperationException("La cola está vacía");
            }
            return _elementos.First.Value;
        }
    }
}
