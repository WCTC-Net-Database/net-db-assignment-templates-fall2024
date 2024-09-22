namespace W7_assignment_template.Interfaces;

public interface ICharacter
{
    string Name { get; set; }

    void Attack(ICharacter target);
    void EnterRoom(IRoom room);
    void Move(string? direction = null);
}
