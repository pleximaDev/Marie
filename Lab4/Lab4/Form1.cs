using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab4
{
    class TrapdoorFunc { }

    public partial class Form1 : Form
    {
        private Graphics g;
        private Point click;
        private TicTacToe game;
        private (int size, int combo) gameMode = (10, 5);
        ToolStripLabel infoLabel;

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateScore()
        {
            label2.Text = $"Noughts' Player:\n{game.scoreNought}";
            label3.Text = $"Crosses' Player:\n{game.scoreCross}";
        }

        public void UpdateStatus(string txt)
        {
            toolStripStatusLabel1.Text = $"{gameMode.size.ToString()}x{gameMode.size.ToString()}";
            infoLabel.Text = txt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new TicTacToe(new Pen(Color.Red, 4.0f), new Pen(Color.Green, 4.0f), gameMode.size, gameMode.combo);
            infoLabel = new ToolStripLabel();
            UpdateScore();
            toolStripStatusLabel1.Text = $"{gameMode.size.ToString()}x{gameMode.size.ToString()}";
            this.statusStrip1.Items.Add(infoLabel);

            MessageBox.Show($"Significant piece == 0x{( (0x29^17)>>1 ).ToString("x2")} 0x{( (0xb6^02)>>2 ).ToString("x2")} 0x{( (0x1e6^22)>>3 ).ToString("x2") }", "Hint...");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            game.RenderPlayground(g);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) { }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;
            game.ClickProcessing(g, click);
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RestartGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            game.RestartGame();
        }

        private void RestartGame()
        {
            this.Invalidate();
            game = new TicTacToe(new Pen(Color.Red, 4.0f), new Pen(Color.Green, 4.0f), gameMode.size, gameMode.combo);
            UpdateScore();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)   { gameMode = (3, 3); this.RestartGame();    }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)  { gameMode = (10, 5); this.RestartGame();   }

        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)  { gameMode = (32, 16); this.RestartGame();  }

        private void x50ToolStripMenuItem_Click(object sender, EventArgs e)  { gameMode = (50, 25); this.RestartGame();  }

        private void x128ToolStripMenuItem_Click(object sender, EventArgs e) { gameMode = (100, 50); this.RestartGame(); }
        
        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            game.LoadSave(g);
            UpdateScore();
        }
    }

    private abstract class TBBT /* Palindrome entry point */
    {
        private protected readonly string hint        = "The text is encoded with the key",
                                          key         = "0x1C0x..0x..0x.C" + "a" + "place", /* Transform */
                                          hint2       = "This is a reference to the ... transform, so use only the last word as a key",
                                          encodedText = "Rrtptkrrs, spat Qlrxl :3 Wgpnobp tq ClCR (Jev eyoiset gzmetlgv nobainic, ow yo, " +
                                          "kx'd a hwiileln oihjprtyt vsair, T jwwe mtlnv Cpt pyovlpr Rcecxtvt Nrwmde) isrqyrh ise gbaacdeu sq " +
                                          "Cdxpwxpr Hnigrne. Ise piit heer md td oeesoe herkrr twlt kw worltgh tn rwauw Dercev. Xsih dttmyg xd " +
                                          "epgzdto wkxs ATD-128. Kgc == 'WaewaeiErpyshscm'. Xyivmllxkavmzn kpcvsc (IK) ts esycpeepeeidy oh 2 lpx " +
                                          "kllwid (emlmrpp: '2d 3t' + '1n 4c' == '2f 3i 1n 4c'). Utrux sem ganyp ih zbvetnto ftsx twp fqpwoltni jzrbflc: " +
                                          "lpxKllwi1 = e * L^(-1){A{S(t)}}. Ylprt e iu xse Jyiz xtmtdtcqa ou xy hmcsi xeuwlgt depx eo nzu, N^(-1){} md Icgetwp " +
                                          "Lpalcgp tglnujzrb, W{} iu yyialtgvll strgge Lpalcgp tglnujzrb, S(t) kw Sepgiumoe heer jfnreiqr (Tnipgteeidy oh xse Strcg " +
                                          "oeaea hyycit). Sggzns sez zlljp iu wtgctfkglni aiggp ewkgp...";

        private void VigenereCipher(string key) { }

        private void EasyWin()
        {
            string base64 = "Tm90IHRoYXQgZWFzeSA7KSBCdXQgcmVtZW1iZXI6IHZlcnkgYmlnIG51bWJlciA9PiBwcm9iYWJseSBUdXBwZXIncyBGb3JtdWxhLi4uIA==";
        }
    }

    private class Secret
    {
        private AES128(string ciphertext, string key /* UTF8 */, string IV /* hex */) { }

        string ciphertext = "aaf79282f5c01f87bac780bb02387087be37df67f9e1433a7a5e0b1350eba2ebd5438d1d87be75c11d66c627e5bdee3600dadd546a2c5e62bcb61d5a4b9" +
        "57f4504d6703b1a8ad8eb7f97bdbf83baa762ad9cf2ee94d2e748cce36b2fa4b66af1fab62479004a2780f7ed3da9724f73c2460ef0603ad277fa973ecfdf7462885121b2cabfa4" +
        "95f25694b609a281a75507e89a03dd10a6b4ba80260d0401ff672db05e2cccaa5ded16f6bdbe1c4920e01e225d95a9f399865c0b69348092a9e03db46b43a2c71bd3079435c03ab" +
        "a930b0027afdce3ca3e7ad7593ae000544f097419fecd9096e38198bf7eb2345197a38888ee4fe7373001c9580ca0c2df9fff879fc69badf38bca2421562fd2ad41024d1120573d" +
        "d90efee9edc8eb9e2f268e88c62d2132f8295dfff0e40b00707f2434954d761dbccecd9ba607951a6ce8c1c1e9d1eea6f309cb086b4796fbee3bc3d19b05386e04e605f55652ec4" +
        "c727ee6527d30240468c4d4c25c589f9a8e13b637ca24ad27a7e00eddcba52df1572b41605bbcf9fef6a88cb9076c8c877072b69965df2e7059b8bea440efe5e7c54f0e57762df7" +
        "cd7f0cb8e60c7c8e2f9018e63a070d1e4a7cb269aa442a7b039778ce40f0516b01b7241e0681e5e73a5727605b1a7dcb88e25ab95286d0b627677cfbdb254a6e3d6de2823be7ace" +
        "c6c585a89b68289a13b9d97151d85e894b5eaa487934dbdea9dd2080588179b9cb9ba5d5de01c69d4a0023f8928e8eabcc0c2dabe8600de6ca50c108cbc4bde69e4a3cd51b3927c" +
        "45c5ea366399b91817a8a746b866a8603dd1d3c05bf52fe44619f56bb49dcc031067ea0906f8d9ecfd84a2ae3743938fbd6c408ee9131a6e35a94df747ccdbc75dff1b30bf7dac1" +
        "3170848100ce61adc32d46520d498301b59f3edac0d9e44f4e1b3371e3d5c83ab28fc00848d2fc052aa39c1d625ee8fc57f0146a5796d313b33e140a0a8f096d7e921160edaf01d" +
        "f9134d651157e280c1c720f63497de79dbd34ddb9d02eac67764d794f6efc9972d1d2ee2ff539de2878fdcc90f2c77bf7123ef68fde5e270c1af96113f5197efd5caf05c48a7180" +
        "33eb60f786b349fd056091e9e980a2db84b383a0788aa32a93adcfcbfe9441ba873c049fca5d7e60a6883e790e7f6bddaf81cb2ed60820d7cdf3eb129d1ff4c44ed3cf688e42bbe" +
        "edf674c339692ed2fb28e818c2d5550bdcd7c6bea4bd5997baf1a3980c4be83554e65f79ca72ca56777294d99c7013d032ecdf9b51d5c07d0ec84a220a5b68c7";
    }

    private class RSA { }

    public class TicTacToe : Form1
    {
        private Pen crossPlayerPen  = Pens.Black,
                    NoughtPlayerPen = Pens.Black,
                    WinningLinePen  = new Pen(Color.BlueViolet, 5.0f),
                    BorderPen       = new Pen(Color.FromArgb(188, 0x2D, 0x3E, 0x4F), 6.0f),
                    StructurePen    = new Pen(Color.DarkGray, 3.0f);

        private int numOfCells  = 3,
                    winnerCombo = 3;
        private static int
                    cellSize, gap;

        private (int x, int y) strtPnt = (250, 250),
                               endPnt  = (1000, 1000);
        
        private bool turn = false;

        private char[,] state;

        private Cell[,] cells;

        private string 
            /*logPath = @"AutoSave.txt",*/
            statePath       = @"state.bin",
            scoreCrossPath  = @"scoreCross.bin",
            scoreNoughtPath = @"scoreNought.bin";

        private (string winner, Point[] winningLine) WinnerChecker(char[,] array2check)
        {
            int crossesCombo = 0, noughtsCombo = 0;
            string winner = "None";
            Point[] winningLine = new Point[2];

            for (int i = 0; i < numOfCells; ++i, crossesCombo = noughtsCombo = 0)
                for (int j = 0; j < numOfCells; ++j)
                    if (WinnerCheckerCondition(i, j, array2check[i, j], ref crossesCombo, ref noughtsCombo, ref winner, ref winningLine)) return (winner, winningLine);

            for (int j = 0; j < numOfCells; ++j, crossesCombo = noughtsCombo = 0)
                for (int i = 0; i < numOfCells; ++i)
                    if (WinnerCheckerCondition(i, j, array2check[i, j], ref crossesCombo, ref noughtsCombo, ref winner, ref winningLine)) return (winner, winningLine);

            /* Diagonal */
            for (int i = -numOfCells + 1; Math.Abs(i) < numOfCells; ++i)
                for (int j = 0; j <= numOfCells - Math.Abs(i) - 1; ++j)
                {
                    int row    = i < 0 ? j : (i + j);
                    int column = i > 0 ? j : (Math.Abs(i) + j);
                    if (WinnerCheckerCondition(row, column, array2check[row, column], ref crossesCombo, ref noughtsCombo, ref winner, ref winningLine)) return (winner, winningLine);
                }

            /* Anti-diagonal */
            for (int i = -numOfCells + 1, t = 0; Math.Abs(i) < numOfCells; ++i, ++t)
                for (int j = 0, l = t; j <= numOfCells - Math.Abs(i) - 1; ++j, l--)
                {
                    int row    = i < 0 ? j       : (i + j);
                    int column = i > 0 ? (l - i) : l;
                    if (WinnerCheckerCondition(row, column, array2check[row, column], ref crossesCombo, ref noughtsCombo, ref winner, ref winningLine)) return (winner, winningLine);
                }

            for (int i = 0; i < numOfCells; ++i)
                for (int j = 0; j < numOfCells; ++j)
                    if (array2check[i, j] == '\0') return (winner, winningLine);

            return ("Tie", winningLine);
        }

        private bool WinnerCheckerCondition(int i, int j, char array2check, ref int crossesCombo, ref int noughtsCombo, ref string winner, ref Point[] winningLine)
        {
            switch (array2check)
            {
                case 'X': case 'x':
                    ++crossesCombo;
                    if (noughtsCombo > 0) noughtsCombo = 0;
                    if (crossesCombo == 1) winningLine[0] = cells[i, j].position;
                    break;
                case 'O': case 'o':
                    ++noughtsCombo;
                    if (crossesCombo > 0) crossesCombo = 0;
                    if (noughtsCombo == 1) winningLine[0] = cells[i, j].position;
                    break;
                case '\0':
                    if (noughtsCombo > 0) noughtsCombo = 0;
                    if (crossesCombo > 0) crossesCombo = 0;
                    break;
                default:
                    throw new System.ComponentModel.InvalidEnumArgumentException();
            }
            
            if      (crossesCombo == winnerCombo) { winner = "Crosses";  winningLine[1] = cells[i, j].position; return true; }
            else if (noughtsCombo == winnerCombo) { winner = "Noughts";  winningLine[1] = cells[i, j].position; return true; }
            else return false;
        }

        private void GameOver(Graphics g, (string winner, Point[] winningLine) result)
        {
            PrintWinningLine(g, result.winningLine);

            switch (result.winner)
            {
                case "Noughts":
                    ++scoreNought;
                    break;
                case "Crosses":
                    ++scoreCross;
                    break;
                default:
                    throw new System.ComponentModel.InvalidEnumArgumentException();
            }

            Application.OpenForms.OfType<Form1>().FirstOrDefault().UpdateScore();

            if (MessageBox.Show($"{result.winner} have won this round! Do you want to play again?", "Game Over!",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry)
            {
                Application.OpenForms.OfType<Form1>().FirstOrDefault().Invalidate();
                RestartGame();
            }
            else { Application.OpenForms.OfType<Form1>().FirstOrDefault().Close(); }
        }

        private Action<object, string> logger = (object variable, string path) =>
        {
            var formatter = new BinaryFormatter();
            var stream    = new MemoryStream();
            formatter.Serialize(stream, variable);
            stream.Position = 0;
            var obj = formatter.Deserialize(stream);

            using (StreamWriter sw = File.AppendText(path)) { }
            using (Stream s = File.Open(path, FileMode.Open)) { formatter.Serialize(s, variable); }
        };

        private Action<object, string> loader = (object variable, string path) =>
        {
            if (variable is char[,])  variable = (char[,]) new BinaryFormatter().Deserialize(File.OpenRead(path));
            else if (variable is int) variable = (int) new BinaryFormatter().Deserialize(File.OpenRead(path));
        };

        private void Log2File()
        {
            logger(state,             statePath);
            logger(scoreCross,   scoreCrossPath);
            logger(scoreNought, scoreNoughtPath);
        }

        private void LoadFromFile()
        {
            using (Stream s = File.OpenRead(statePath)) { state       = (char[,])new BinaryFormatter().Deserialize(s);                          }
            using (Stream s = File.OpenRead(statePath)) { scoreCross  = (int)new BinaryFormatter().Deserialize(File.OpenRead(scoreCrossPath));  }
            using (Stream s = File.OpenRead(statePath)) { scoreNought = (int)new BinaryFormatter().Deserialize(File.OpenRead(scoreNoughtPath)); }
            MessageBox.Show($"{state[0, 0]}");

            /*
             * loader(state, statePath);
             * loader(scoreCross, scoreCrossPath);
             * loader(scoreNought, scoreNoughtPath);
             */
        }

        private class Cell
        {
            public Point position { get; set; }

            public Cell(Point pos) { position = pos; }

            public static bool operator ==
            (Cell cl1, Cell cl2)
            {
                return
                (
                    (cl1.position.X > cl2.position.X)            &&
                    (cl1.position.X < cl2.position.X + cellSize) &&
                    (cl1.position.Y > cl2.position.Y)            &&
                    (cl1.position.Y < cl2.position.Y + cellSize)
                )
                ? true : false;
            }

            public static bool operator !=
            (Cell cl1, Cell cl2)
            {
                return
                (
                    (cl1.position.X > cl2.position.X)            &&
                    (cl1.position.X < cl2.position.X + cellSize) &&
                    (cl1.position.Y > cl2.position.Y)            &&
                    (cl1.position.Y < cl2.position.Y + cellSize)
                )
                ? false : true;
            }

            public override int GetHashCode() { throw new NotImplementedException(); }

            public override bool Equals(object obj) { return Equals((Cell)obj); }

            public bool Equals(Cell comparable)
            {
                return
                (
                    (comparable.position.X > this.position.X)            &&
                    (comparable.position.X < this.position.X + cellSize) &&
                    (comparable.position.Y > this.position.Y)            &&
                    (comparable.position.Y < this.position.Y + cellSize)
                )
                ? true : false;
            }
        }

        public int scoreCross  = 0,
                   scoreNought = 0;

        public TicTacToe(Pen crossPlayerPen, Pen NoughtPlayerPen, int numOfCells, int winnerCombo)
        {
            this.crossPlayerPen  = crossPlayerPen;
            this.NoughtPlayerPen = NoughtPlayerPen;
            this.numOfCells      = numOfCells;
            this.winnerCombo     = winnerCombo;

            cellSize = endPnt.x / numOfCells;
            gap = cellSize / 5;
            cells = new Cell[this.numOfCells, this.numOfCells];
            state = new char[this.numOfCells, this.numOfCells];

            for (int i = 0; i < numOfCells; ++i)
                for (int j = 0; j < numOfCells; ++j)
                    cells[i, j] = new Cell(new Point(strtPnt.y + i * cellSize, strtPnt.x + j * cellSize));
        }

        public void RenderPlayground(Graphics g)
        {
            Application.OpenForms.OfType<Form1>().FirstOrDefault().UpdateStatus(turn ? "Crosses' Player's turn" : "Noughts' Player's turn");
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(strtPnt.x, strtPnt.y, endPnt.x, endPnt.y));
            
            g.DrawLine(BorderPen, strtPnt.x, strtPnt.y, strtPnt.x, endPnt.y + strtPnt.y);
            g.DrawLine(BorderPen, strtPnt.x + endPnt.x, strtPnt.y, strtPnt.x + endPnt.x, endPnt.y + strtPnt.y);
            g.DrawLine(BorderPen, strtPnt.x, strtPnt.y, strtPnt.x + endPnt.x, strtPnt.y);
            g.DrawLine(BorderPen, strtPnt.x, strtPnt.y + endPnt.y, strtPnt.x + endPnt.x, strtPnt.y + endPnt.y);

            for (int i = 1; i < numOfCells; ++i)
            {
                g.DrawLine(StructurePen, strtPnt.x + i * cellSize, strtPnt.y, strtPnt.x + i * cellSize, strtPnt.y + endPnt.y);
                g.DrawLine(StructurePen, strtPnt.x, strtPnt.y + i * cellSize, strtPnt.x + endPnt.x, strtPnt.y + i * cellSize);
            }
        }

        public void ClickProcessing(Graphics g, Point click)
        {
            for (int i = 0; i < numOfCells; ++i)
                for (int j = 0; j < numOfCells; ++j)
                    if (!(cells[i, j] is null) && new Cell(click) == cells[i, j] && state[i, j] == '\0')
                    {
                        if (turn) { PrintCross(g, cells[i, j].position); state[i, j] = 'X'; turn = false; }
                        else      { PrintNought(g, cells[i, j].position); state[i, j] = 'O'; turn = true; }
                        Application.OpenForms.OfType<Form1>().FirstOrDefault().UpdateStatus(turn ? "Crosses' Player's turn" : "Noughts' Player's turn");
                        if(WinnerChecker(state).winner != "None") GameOver(g, WinnerChecker(state));
                        Log2File();
                        return;
                    }
        }

        public void RestartGame()
        {
            cells = new Cell[this.numOfCells, this.numOfCells];
            state = new char[this.numOfCells, this.numOfCells];

            for (int i = 0; i < numOfCells; ++i)
                for (int j = 0; j < numOfCells; ++j)
                    cells[i, j] = new Cell(new Point(strtPnt.y + i * cellSize, strtPnt.x + j * cellSize));
        }

        public void PrintCross(Graphics g, Point coordinates)
        {
            g.DrawLine(crossPlayerPen, coordinates.X + gap, coordinates.Y + gap, coordinates.X + cellSize - gap, coordinates.Y + cellSize - gap);
            g.DrawLine(crossPlayerPen, coordinates.X + gap, coordinates.Y + cellSize - gap, coordinates.X + cellSize - gap, coordinates.Y + gap);
        }

        public void PrintNought(Graphics g, Point coordinates)
        {
            g.DrawEllipse(NoughtPlayerPen, coordinates.X + gap / 2, coordinates.Y + gap / 2, cellSize - gap, cellSize - gap);
        }

        public void PrintWinningLine(Graphics g, Point[] coordinates)
        {
            if (coordinates[0].X == coordinates[1].X)
                g.DrawLine(WinningLinePen, coordinates[0].X + cellSize / 2, coordinates[0].Y, coordinates[1].X + cellSize / 2, coordinates[1].Y + cellSize);
            else if (coordinates[0].Y == coordinates[1].Y)
                g.DrawLine(WinningLinePen, coordinates[0].X, coordinates[0].Y + cellSize / 2, coordinates[1].X + cellSize, coordinates[1].Y + cellSize / 2);
            else if (coordinates[0].Y < coordinates[1].Y)
                g.DrawLine(WinningLinePen, coordinates[0].X, coordinates[0].Y, coordinates[1].X + cellSize, coordinates[1].Y + cellSize);
            else if (coordinates[0].Y > coordinates[1].Y)
                g.DrawLine(WinningLinePen, coordinates[0].X, coordinates[0].Y + cellSize, coordinates[1].X + cellSize, coordinates[1].Y);

        }

        public void LoadSave(Graphics g)
        {
            LoadFromFile();
            RerenderState(g);
        }

        public void RerenderState(Graphics g)
        {
            for (int i = 0; i < numOfCells; ++i)
                for (int j = 0; j < numOfCells; ++j)
                    if (state[i, j] == 'X') { PrintCross(g, cells[i, j].position); }
                    else if (state[i, j] == 'O') { PrintNought(g, cells[i, j].position); }
        }
    }

    class ReedSolomon { }

    class Steganography { }
}
