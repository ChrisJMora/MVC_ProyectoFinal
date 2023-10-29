using System.Drawing.Printing;

namespace MVC_ProyectoFinal.Areas.Vuelos.Models
{
    public class Vuelo
    {
        private int _aerolinea;
        private bool _clase;
        //Economico = true; Preferencial = false
        private int _destino;

        private DateOnly _fSalida;
        private TimeOnly _hAbordaje;
        private TimeOnly _hLlegada;
        private TimeOnly _hSalida;
        private int _id;
        private int _origen;
        private int _plzEconomicas;
        private int _plzPreferenciales;
        private double _precio;
        private double _precioPreferencial;
        public Vuelo(int id, int aerolinea, bool clase, int destino, DateOnly fSalida,
            TimeOnly hAbordaje, TimeOnly hSalida, TimeOnly hLlegada, int origen,
            double precio, int plzEconomicas, int plzPreferenciales)
        {
            _id = id;
            _aerolinea = aerolinea;
            _clase = clase;
            _destino = destino;
            _fSalida = fSalida;
            _hAbordaje = hAbordaje;
            _hSalida = hSalida;
            _hLlegada = hLlegada;
            _origen = origen;
            _precio = precio;
            _precioPreferencial = _precio + (_precio * 0.5);
            _plzEconomicas = plzEconomicas;
            _plzPreferenciales = plzPreferenciales;
        }

        public Vuelo()
        {
            _id = 0;
            _aerolinea = 0;
            _clase = false;
            _destino = 0;
            _fSalida = new DateOnly();
            _hAbordaje = new TimeOnly();
            _hSalida = new TimeOnly();
            _hLlegada = new TimeOnly();
            _origen = 0;
            _precio = 0;
            _plzEconomicas = 0;
            _plzPreferenciales = 0;
        }

        public int Aerolinea { get => _aerolinea; set => _aerolinea = value; }

        public bool Clase { get => _clase; set => _clase = value; }

        public int Destino { get => _destino; set => _destino = value; }

        public DateOnly FSalida { get => _fSalida; set => _fSalida = value; }

        public TimeOnly HAbordaje { get => _hAbordaje; set => _hAbordaje = value; }

        public TimeOnly HLlegada { get => _hLlegada; set => _hLlegada = value; }

        public TimeOnly HSalida { get => _hSalida; set => _hSalida = value; }

        public int Id { get => _id; set => _id = value; }
        public int Origen { get => _origen; set => _origen = value; }

        public int PlzEconomicas { get => _plzEconomicas; set => _plzEconomicas = value; }

        public int PlzPreferenciales { get => _plzPreferenciales; set => _plzPreferenciales = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public string? obtnAerolinea(int id, List<Aerolinea>? aerolineas)
        {
            if (aerolineas == null) { return null; }
            return aerolineas.Find(x => x.IdAerolinea == id)?.NombreAerolinea;
        }

        public string? obtnCiudad(int id, List<Ciudad>? ciudades)
        {
            if (ciudades == null) { return null; }
            return ciudades.Find(x => x.Id == id)?.Nombre;
        }

        public double calcPrecioAdulto(int numAdultos)
        {
            if (_clase) { return _precio * numAdultos;  }
            return _precioPreferencial * numAdultos;
        }

        public double calcPrecioMenorEdad(int numMenorEdad)
        {
            if (_clase) { return (_precio - (_precio * 0.5)) * numMenorEdad; }
            return (_precioPreferencial - (_precioPreferencial * 0.5)) * numMenorEdad;
        }

        public double obtnPrecioPreferencial()
        {
            return _precio + (_precio * 0.5);
        }

        public string obtnTiempoVuelo()
        {
            return (_hLlegada - _hSalida).ToString(@"hh\h" + @"mm\m");
        }

        public override string ToString()
        {
            return $"Vuelo: #{_id}, Origen: {_origen},  Destino: {_destino}," +
                $"    Fecha de Salida: {_fSalida}";
        }
    }
}
