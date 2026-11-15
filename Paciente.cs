namespace Tarea_4
{
    public class Paciente
    {
        public Paciente() { }
        public Paciente(int id, string name, DateOnly birthday, long phonenumber, long document, string email)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Phonenumber = phonenumber;
            Document = document;
            Email = email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public long Phonenumber { get; set; }
        public long Document { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"{Id,-4}{Name,-30}{Birthday,-20}{Phonenumber,-15}{Email,-35}{Document,-15}";
        }

        public static void ShowAll(List<Paciente> pacientes)
        {
            Console.WriteLine("A continuación se mostrarán los pacientes listados:");
            Console.WriteLine($"{"ID",-4}{"Nombre",-30}{"Fecha Nacimiento",-20}{"Teléfono",-15}{"Email",-35}{"Documento",-15}");
            foreach (Paciente p in pacientes)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
