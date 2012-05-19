using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSStat.Model;

namespace WSStat.Repository
{
    public interface IEquipmentRepository
    {
        Manufacturer AddManufacturer(Manufacturer manufacturer);
        Board AddBoard(Board board);
        Sail AddSail(Sail sail);

        Manufacturer GetManufacturer(string name);
        ICollection<Manufacturer> Manufacturers { get; }

        Board GetBoard(string name, int volume);
        BoardModel GetBoardModel(string name);
        ICollection<BoardModel> BoardModels { get; }

        Sail GetSail(string name, double size);
        SailModel GetSailModel(string name);
        ICollection<SailModel> SailModels { get; }
    }
}
