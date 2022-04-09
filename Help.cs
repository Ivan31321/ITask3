using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITask3
{
    internal static class Help
    {
        public static void ShowHelp(List<string> moves)
        {
            DataTable dt = new DataTable();
            AddColumns(dt, moves);
            AddRows(dt, moves);
            ShowTable(dt);
        }
        public static void AddColumns(DataTable dt,List<string> moves)
        {
            dt.Columns.Add(" ");
            foreach (string move in moves)
            {
                dt.Columns.Add(move);
            }
        }
        public static void AddRows(DataTable dt,List<string> moves)
        {
            Object[] rows = new Object[dt.Columns.Count - 1];
            for (int i = 0; i < rows.Length; i++) rows[i] = GetRow(dt.Columns.Count, i, moves);
            foreach (Object[] row in rows) dt.Rows.Add(row);
        }
        public static Object[] GetRow(int ColumnsCount,int movePosition,List<string> moves)
        {
            Object[] row = new Object[ColumnsCount];
            for(int i = 0; i < ColumnsCount; i++)
            {
                if (i != 0)
                {
                    string answer = FindWinner(movePosition,i-1,moves.Count);
                    row[i] = answer;
                }
                else row[i] = moves[movePosition];
            }
            return row;
        }
        public static string FindWinner(int movePosition,int i,int count)
        {
            string answer = "";
            if (movePosition == i) answer = "Draw";
            else if ((movePosition < i && i - movePosition <= (count - 1) / 2) ||
                (movePosition > i && count - movePosition + i <= (count - 1) / 2))
            {
                answer = "You win!";
            }
            else answer = "You lose(";
            return answer; 
        }
        public static void ShowTable(DataTable table)
        {
            foreach (DataColumn col in table.Columns) Console.Write("{0,-20}", col.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns) Console.Write("{0,-20}", row[col]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
