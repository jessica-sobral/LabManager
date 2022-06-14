namespace LabManager.Models;

class Lab
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Block { get; set; }

    public Lab(int id, string number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}