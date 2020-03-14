using System.Data;
namespace Basica
{
    public interface IJSON
    {
        string TableToJSON(DataTable T);
        string RowToJSON(DataRow T);
    }
}