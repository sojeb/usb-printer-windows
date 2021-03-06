
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfiumViewer;
using Spire.Pdf;
using Spire.Pdf.Barcode;
using Spire.Pdf.Graphics;
using Syncfusion.Windows.Forms.Barcode;
using System;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Xml.Linq;
using PdfDocument = PdfiumViewer.PdfDocument;

namespace MYPRINTER
{

    public partial class MainForm : Form
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string a4PrinterData = "[{\"id\":\"402\",\"cn_number\":\"1000040000402\",\"sender_contact_no\":\"01990352988\",\"sender_reference\":\"test\",\"sender_name\":\"sojeb\",\"sender_address\":\"Noakhali-HUB\",\"receiver_contact_no\":\"01990352988\",\"receiver_name\":\"popular\",\"receiver_address\":\"Barishal\",\"created_at\":\"2022-05-2916:35:23.000\",\"print_status\":\"0\",\"total_lot_qty\":\"4\",\"condition_amount\":\".00\",\"condition_mms_charge\":\".00\",\"is_home_delivery\":\"1\",\"net_amount\":\"250.00\",\"user_name\":\"NasrullahAlJadid\",\"sender_branch_name\":\"DHAKA-HUB\",\"receiver_branch_name\":\"Barishal\",\"department_name\":\"Courier\",\"service_name\":\"Document\",\"item_qty\":\"1\",\"items\":\"AMBBattery(Ctn)\"},{\"id\":\"402\",\"cn_number\":\"1000040000402\",\"sender_contact_no\":\"01990352988\",\"sender_reference\":\"test\",\"sender_name\":\"ACI\",\"sender_address\":\"DHAKA-HUB\",\"receiver_contact_no\":\"01990352988\",\"receiver_name\":\"popular\",\"receiver_address\":\"Barishal\",\"created_at\":\"2022-05-2916:35:23.000\",\"print_status\":\"0\",\"total_lot_qty\":\"4\",\"condition_amount\":\".00\",\"condition_mms_charge\":\".00\",\"is_home_delivery\":\"1\",\"net_amount\":\"250.00\",\"user_name\":\"NasrullahAlJadid\",\"sender_branch_name\":\"DHAKA-HUB\",\"receiver_branch_name\":\"Barishal\",\"department_name\":\"Courier\",\"service_name\":\"Document\",\"item_qty\":\"1\",\"items\":\"AMBBattery(Ctn)\"}]";
        string thermalPrinterData = "[{\"id\":\"402\",\"cn_number\":\"1000040000402\",\"branch_id\":\"12\",\"receiver_branch_id\":\"2\",\"sender_contact_no\":\"01990352988\",\"sender_reference\":\"test\",\"sender_name\":\"ACI\",\"receiver_contact_no\":\"01990352988\",\"receiver_name\":\"popular\",\"receiver_address\":\"Barishal\",\"created_at\":\"2022-05-29 16:35:23.000\",\"print_status\":\"0\",\"total_lot_qty\":\"4\",\"item_qty\":\"1\",\"lot_qty\":\"4\",\"lot_number\":\"1000040000402000\",\"is_home_delivery\":\"1\",\"user_name\":\"NasrullahAlJadid\",\"sender_branch_name\":\"DHAKA-HUB\",\"receiver_branch_name\":\"Barishal\",\"receiver_branch_name_bd\":\"বরিশাল\",\"department_name\":\"Courier\",\"service_name\":\"Document\",\"item_name\":\"AMBBattery\",\"unit_name\":\"Ctn\"},{\"id\":\"402\",\"cn_number\":\"1000040000402\",\"branch_id\":\"12\",\"receiver_branch_id\":\"2\",\"sender_contact_no\":\"01990352988\",\"sender_reference\":\"test\",\"sender_name\":\"ACI\",\"receiver_contact_no\":\"01990352988\",\"receiver_name\":\"popular\",\"receiver_address\":\"Barishal\",\"created_at\":\"2022-05-29 16:35:23.000\",\"print_status\":\"0\",\"total_lot_qty\":\"4\",\"item_qty\":\"1\",\"lot_qty\":\"4\",\"lot_number\":\"1000040000402001\",\"is_home_delivery\":\"1\",\"user_name\":\"NasrullahAlJadid\",\"sender_branch_name\":\"DHAKA-HUB\",\"receiver_branch_name\":\"Barishal\",\"receiver_branch_name_bd\":\"বরিশাল\",\"department_name\":\"Courier\",\"service_name\":\"Document\",\"item_name\":\"AMBBattery\",\"unit_name\":\"Ctn\"},{\"id\":\"402\",\"cn_number\":\"1000040000402\",\"branch_id\":\"12\",\"receiver_branch_id\":\"2\",\"sender_contact_no\":\"01990352988\",\"sender_reference\":\"test\",\"sender_name\":\"ACI\",\"receiver_contact_no\":\"01990352988\",\"receiver_name\":\"popular\",\"receiver_address\":\"Barishal\",\"created_at\":\"2022-05-29 16:35:23.000\",\"print_status\":\"0\",\"total_lot_qty\":\"4\",\"item_qty\":\"1\",\"lot_qty\":\"4\",\"lot_number\":\"1000040000402002\",\"is_home_delivery\":\"1\",\"user_name\":\"NasrullahAlJadid\",\"sender_branch_name\":\"DHAKA-HUB\",\"receiver_branch_name\":\"Barishal\",\"receiver_branch_name_bd\":\"বরিশাল\",\"department_name\":\"Courier\",\"service_name\":\"Document\",\"item_name\":\"AMBBattery\",\"unit_name\":\"Ctn\"},{\"id\":\"402\",\"cn_number\":\"1000040000402\",\"branch_id\":\"12\",\"receiver_branch_id\":\"2\",\"sender_contact_no\":\"01990352988\",\"sender_reference\":\"test\",\"sender_name\":\"ACI\",\"receiver_contact_no\":\"01990352988\",\"receiver_name\":\"popular\",\"receiver_address\":\"Barishal\",\"created_at\":\"2022-05-29 16:35:23.000\",\"print_status\":\"0\",\"total_lot_qty\":\"4\",\"item_qty\":\"1\",\"lot_qty\":\"4\",\"lot_number\":\"1000040000402003\",\"is_home_delivery\":\"1\",\"user_name\":\"NasrullahAlJadid\",\"sender_branch_name\":\"DHAKA-HUB\",\"receiver_branch_name\":\"Barishal\",\"receiver_branch_name_bd\":\"বরিশাল\",\"department_name\":\"Courier\",\"service_name\":\"Document\",\"item_name\":\"AMBBattery\",\"unit_name\":\"Ctn\"}]";
        List<A4Printer> a4Printers;
        List<TharmalPrinter> thermalPrinters;

        PdfCode93Barcode code93 = new PdfCode93Barcode();
        int i = 0;
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]



        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        public class A4Printer
        {
            public string id { get; set; }
            public string cn_number { get; set; }
            public string sender_contact_no { get; set; }
            public string sender_reference { get; set; }
            public string sender_name { get; set; }
            public string sender_address { get; set; }
            public string receiver_contact_no { get; set; }
            public string receiver_name { get; set; }
            public string receiver_address { get; set; }
            public string created_at { get; set; }
            public string print_statu { get; set; }
            public string total_lot_qty { get; set; }
            public string condition_amount { get; set; }
            public string condition_mms_charge { get; set; }
            public string is_home_delivery { get; set; }
            public string net_amount { get; set; }
            public string user_name { get; set; }
            public string sender_branch_name { get; set; }
            public string receiver_branch_name { get; set; }
            public string department_name { get; set; }
            public string service_name { get; set; }
            public string item_qty { get; set; }
            public string items { get; set; }
        }

        public class TharmalPrinter
        {
            public string id { get; set; }
            public string cn_number { get; set; }
            public string branch_id { get; set; }
            public string receiver_branch_id { get; set; }
            public string sender_contact_no { get; set; }
            public string sender_reference { get; set; }
            public string sender_name { get; set; }
            public string sender_address { get; set; }
            public string receiver_contact_no { get; set; }
            public string receiver_name { get; set; }
            public string receiver_address { get; set; }
            public string created_at { get; set; }
            public string print_status { get; set; }
            public string total_lot_qty { get; set; }
            public string lot_number { get; set; }
            public string is_home_delivery { get; set; }
            public string user_name { get; set; }
            public string sender_branch_name { get; set; }
            public string receiver_branch_name { get; set; }
            public string receiver_branch_name_bd { get; set; }
            public string department_name { get; set; }
            public string service_name { get; set; }
            public string item_qty { get; set; }
            public string item_name { get; set; }
            public string unit_name { get; set; }
        }
      


        Code39Setting code39Settings = new Code39Setting();
       public static Code128ASetting code128ASetting = new Code128ASetting();


        public MainForm()
        {
            InitializeComponent();
            convertToJsonObject();


            code39Settings.EnableCheckDigit = true;
            code39Settings.ShowCheckDigit = true;
            code39Settings.EncodeStartStopSymbols = true;
            code39Settings.BarHeight = 100;
            code39Settings.NarrowBarWidth = 1;


            code93.TextDisplayLocation = TextLocation.Bottom;

            //code128ASetting.Dis


        }

        public void convertToJsonObject()
        {

            //  A4Printer[] persons = JsonConvert.DeserializeObject<A4Printer>(a4PrinterData);

            //JavaScriptSerializer js = new JavaScriptSerializer();

            // JavaScriptSerializer
            //A4Printer[] persons = js.Deserialize<A4Printer[]>(a4PrinterData);
            //A4PrinterList list= JsonConvert.DeserializeObject<A4PrinterList>(a4PrinterData);
            //     List < A4Printer >> printers;
            a4Printers = JsonConvert.DeserializeObject<List<A4Printer>>(a4PrinterData);
            thermalPrinters = JsonConvert.DeserializeObject<List<TharmalPrinter>>(thermalPrinterData);
            // System.Diagnostics.Debug.WriteLine("success: " + printers[0].department_name);


        }

        public static String file = "";
        public void callPrinter1()
        {
            // var path = @"C:\\Users\\mdsohiduddin\\Documents\\Bio Data of Nowrin Tabassum.pdf";
            // var document = PdfiumViewer.PdfDocument.Load(path);
            /*   using (var document = printDocument)
               {
                   using (var printDocument = printDocument)
                   {*/
            // printDocument.PrinterSettings.PrintFileName = "Letter_SkidTags_Report_9ae93aa7-4359-444e-a033-eb5bf17f5ce6.pdf";
            i = 0;
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.DocumentName = "file.pdf";
            printDocument.PrinterSettings.PrintFileName = "file.pdf";
            printDocument.PrintController = new StandardPrintController();
            printDocument.Print();
            //  }
            //}
        }
        public static void callPrinter2()
        {
            //  var path = @"C:\\Users\\mdsohiduddin\\Documents\\Bio Data of Nowrin Tabassum.pdf";
            // var document = PdfiumViewer.PdfDocument.Load(path);
            using (var document = PdfDocument.Load(file))
            {
                using (var printDocument = document.CreatePrintDocument())
                {
                    // printDocument.PrinterSettings.PrintFileName = "Letter_SkidTags_Report_9ae93aa7-4359-444e-a033-eb5bf17f5ce6.pdf";

                    printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    printDocument.DocumentName = "file.pdf";
                    printDocument.PrinterSettings.PrintFileName = "file.pdf";
                    printDocument.PrintController = new StandardPrintController();
                    printDocument.Print();
                }
            }
        }

        public static void printData()
        {


            /*  ThreadStart threadStart = new ThreadStart(callPrinter1);
              Thread thread1 = new Thread(threadStart);
              thread1.Start();*/


            ThreadStart threadStart2 = new ThreadStart(callPrinter2);
            Thread thread2 = new Thread(threadStart2);
            thread2.Start();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "document";
            // Win7
            // di.pDataType = "RAW";

            // Win8+
            di.pDataType = "XPS_PASS";


            //  var rawPrinter = new DOC_INFO_1() { pDocName = "My Document", pDataType = "Text" }
            // Open the printer.
            System.Diagnostics.Debug.WriteLine("success: " + pBytes);

            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            System.Diagnostics.Debug.WriteLine("success: " + bSuccess);

            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            bool bSuccess = false;

            try
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // FileStream fs = new FileStream("D:\\Documents and Settings\\sanjay\\Desktop\\shashi.prn",FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            try
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                System.Diagnostics.Debug.WriteLine("our printer name : " + printer);
                if (printer == "Microsoft Print to PDF")
                {
                    //SendStringToPrinter(printer, "i am printer: " + printer);
                    //  SendFileToPrinter(printer, "C:\\Users\\mdsohiduddin\\Documents\\output.txt");
                    System.Diagnostics.Debug.WriteLine("its microstf : " + printer);

                    SendFileToPrinter(printer, "C:\\Users\\mdsohiduddin\\Documents\\Bio Data of Nowrin Tabassum.pdf");
                }
                else if (printer == "AnyDesk Printer")
                {
                    System.Diagnostics.Debug.WriteLine("AnyDesk Printer : " + printer);
                    // SendStringToPrinter(printer,"hello");
                    SendFileToPrinter(printer, "C:\\Users\\mdsohiduddin\\Documents\\output.txt");
                }

                //;
            }

            customerName.Clear();
            Price.Clear();
            totalToPay.Clear();

            ItemName.SelectedIndex = 0;
            Quantity.SelectedIndex = 0;
        }

        private void customerName_TextChanged(object sender, EventArgs e)
        {

        }
        private void updateTotalPrice()
        {
            if (Quantity.Text != "" && Price.Text != "")
            {
                decimal totalPirce = Convert.ToInt32(Quantity.Text) * Convert.ToInt32(Price.Text);
                totalToPay.Text = totalPirce.ToString();
            }
            else
            {
                totalToPay.Text = "0";
            }
        }


        private void Price_TextChanged(object sender, EventArgs e)
        {
            updateTotalPrice();
        }

        private void Quantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTotalPrice();

        }

        private void printPreviewDialog_Load(object sender, EventArgs e)
        {

        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument2;
            printPreviewDialog.ShowDialog();
        }
        int thermalIndex = 0;

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

          

            string[] dateArr = thermalPrinters[thermalIndex].created_at.Split(" ");
            string[] oDate = dateArr[0].Split("-");
            string formatedDate = oDate[1] + "-" + oDate[2] + "-" + oDate[0];
            System.Diagnostics.Debug.WriteLine("its microstf1 : "+ dateArr[0]+"   "+ thermalPrinters[thermalIndex].created_at);

            //DateTime.Now.ToString("MM/dd/yyyy HH:mm")
            // var oDate = DateTime.Parse(dateArr[0]);


          //  DateTime oDate = DateTime.ParseExact(thermalPrinters[thermalIndex].created_at, "MM/dd/yyyyHH:mm:ss", null);


            var dateTime = DateTime.Now;

            String convertedDate = dateTime.ToLongDateString();
              SfBarcode barcode = new SfBarcode();
            barcode.Text = thermalPrinters[thermalIndex].lot_number;
            barcode.SymbologySettings = code128ASetting;

            barcode.Symbology = BarcodeSymbolType.Code128A;
            barcode.TextColor = Color.Black;
           
            //barcode.Font = new Font("Arial", 18, FontStyle.Regular);
            // barcode.Tex = BarcodeTextLocation.Bottom;
            PdfCode93Barcode code93 = new PdfCode93Barcode();
            // barcode.DisplayText = true;
            // code93.Size = new Size(100, 40);
            //code93.Text = thermalPrinters[thermalIndex].lot_number;
          //  code93.Font= new Font("Arial", 18, FontStyle.Regular);
            //Image barCodeimage = code93.ToImage();


            //Save the modified image
            //  MemoryStream stream = new MemoryStream();

            //FixImageOrientation(barCodeimage);
            //barCodeimage.Save(stream, ImageFormat.Jpeg);
            //Load the image from stream
            //  PdfBitmap image = new PdfBitmap(stream);

            Image imBar= barcode.ToImage();
            //  barCodeimage.RotateFlip(RotateFlipType.Rotate90FlipX);



            string fontName = "Arial";
            int fontSize = 9;
            FontStyle fontStyle = FontStyle.Bold;
            int refsTop1 = 10;
            int refsLeft1 = 10;


            e.Graphics.DrawString("Ref: ", new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(refsLeft1, refsTop1));
            e.Graphics.DrawString(thermalPrinters[thermalIndex].sender_reference, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(refsLeft1+30, refsTop1));

            e.Graphics.DrawString(thermalPrinters[thermalIndex].department_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(refsLeft1 + 200, refsTop1));
            e.Graphics.DrawString("("+thermalPrinters[thermalIndex].service_name+")", new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(refsLeft1 + 250, refsTop1));



            int receiverHabNameTop = 100;
            e.Graphics.DrawString(thermalPrinters[thermalIndex].receiver_branch_name_bd, new Font(fontName, 23, FontStyle.Regular), Brushes.Black, new Point(refsLeft1 + 250, receiverHabNameTop));

            int senderToReceiverTop = 140;
            int fontSizeSenderToReceiver = 13;

            SizeF senderBranchNameSize = e.Graphics.MeasureString(thermalPrinters[thermalIndex].sender_branch_name, new Font(fontName, fontSizeSenderToReceiver, fontStyle, GraphicsUnit.Point));


            e.Graphics.DrawString(thermalPrinters[thermalIndex].sender_branch_name, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1 + 200, senderToReceiverTop));
            e.Graphics.DrawString("to", new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1 + 200+ (int)senderBranchNameSize.Width, senderToReceiverTop));
            e.Graphics.DrawString(thermalPrinters[thermalIndex].receiver_branch_name, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1 + 200 + (int)senderBranchNameSize.Width + 30, senderToReceiverTop));

            int barcodeHight = 200;
            e.Graphics.DrawString(thermalPrinters[thermalIndex].cn_number +" / "+ thermalPrinters[thermalIndex].total_lot_qty, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1 + 190, barcodeHight));

            e.Graphics.DrawImage(imBar, new Rectangle(refsLeft1 + 190, barcodeHight+30, 200, 70));
            
            int dayHeight =310;
            e.Graphics.DrawString(convertedDate, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1 , dayHeight));
            e.Graphics.DrawString("O/D", new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1 + 390, dayHeight));

            int itemDescriptionHeight = 350;
            int lineGapeItemDescription = 30;
            e.Graphics.DrawString("Item Description", new Font(fontName, fontSizeSenderToReceiver, FontStyle.Underline| FontStyle.Bold), Brushes.Black, new Point(refsLeft1, itemDescriptionHeight));

            e.Graphics.DrawString(thermalPrinters[thermalIndex].item_name+":"+ thermalPrinters[thermalIndex].item_qty, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1, itemDescriptionHeight+ lineGapeItemDescription));
            e.Graphics.DrawString("Receiver: "+ thermalPrinters[thermalIndex].receiver_name, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1, itemDescriptionHeight+ lineGapeItemDescription*2));
            e.Graphics.DrawString("Contact: " + thermalPrinters[thermalIndex].receiver_contact_no, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1, itemDescriptionHeight+ lineGapeItemDescription*3));


            int receverAdressHeight = 470;
            e.Graphics.DrawString("Receiver Address:", new Font(fontName, fontSizeSenderToReceiver, FontStyle.Underline | FontStyle.Bold), Brushes.Black, new Point(refsLeft1, receverAdressHeight));
            e.Graphics.DrawString( thermalPrinters[thermalIndex].receiver_address, new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1, receverAdressHeight + lineGapeItemDescription ));

            int dateAndUserHeight = 540;
            e.Graphics.DrawString(formatedDate+ "( "+ thermalPrinters[thermalIndex].user_name+")", new Font(fontName, fontSizeSenderToReceiver, fontStyle), Brushes.Black, new Point(refsLeft1+120, dateAndUserHeight));
         

        }


        private Image FixImageOrientation(Image image)
        {
            const int exifOrientationId = 0x112;
            if (!image.PropertyIdList.Contains(exifOrientationId))
                return image;
            //Gets the specified property item from the image
            var property = image.GetPropertyItem(exifOrientationId);
            var orient = BitConverter.ToInt16(property.Value, 0);
            //Get the rotated or flipped image 
            image = RotateImageSrc(orient, image);
            return image;
        }

        private Image RotateImageSrc(int orient, Image image)
        {
            switch (orient)
            {
                case 1:
                    image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    return image;
                case 2:
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    return image;
                case 3:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return image;
                case 4:
                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    return image;
                case 5:
                    image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return image;
                case 6:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return image;
                case 7:
                    image.RotateFlip(RotateFlipType.Rotate270FlipX);
                    return image;
                case 8:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    return image;
                default:
                    image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    return image;
            }
        }
        private static void StartListening()
        {
            System.Diagnostics.Debug.WriteLine("its microstf1 : ");
            HttpListener listener = new HttpListener();

            SetPrefixes(listener);

            if (listener.Prefixes.Count > 0)
            {
                listener.Start();

                while (true)
                {
                    System.Diagnostics.Debug.WriteLine("its microstf2 : ");

                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    System.Diagnostics.Debug.WriteLine("its microstf3 : " + request);


                    String url = request.RawUrl;
                    String[] queryStringArray = url.Split('/');

                    string postedText = GetPostedText(request);
                    JObject o = JObject.Parse(GetPostedText(request)); ;

                    //System.Diagnostics.Debug.WriteLine("its microstf3 : " + o.GetValue("first_printer").ToString());
                    //   System.Diagnostics.Debug.WriteLine("its microstf3 : " + o.GetValue("second_printer").ToString());



                    file = @"D:\file.pdf";

                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }


                    byte[] bytes = Convert.FromBase64String(o.GetValue("first_printer").ToString());
                    System.IO.FileStream stream =
                    new FileStream(file, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    try
                    {
                        // callPrinter1();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("its microstf : " + e.Message);


                    }





                }
            }
        }

        private static void SetPrefixes(HttpListener listener)
        {
            String[] prefixes = new String[] { "http://localhost:8000/" };

            int i = 0;

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
                i++;
            }
        }

        private static string GetPostedText(HttpListenerRequest request)
        {
            string text = "";

            using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            i = 0;
         /*   Console.WriteLine(projectDirectory);
            System.Diagnostics.Debug.WriteLine(projectDirectory);
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            //printDocument.PrinterSettings.PrinterName = "USB_TECH_LBP6230dn";
            printDocument.DocumentName = "file.pdf";
            printDocument.PrinterSettings.PrintFileName = "file.pdf";
            printDocument.PrintController = new StandardPrintController();
            printDocument.Print();
*/

            Console.WriteLine(projectDirectory);
            System.Diagnostics.Debug.WriteLine(projectDirectory);
            printDocument2.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            //printDocument.PrinterSettings.PrinterName = "USB_TECH_LBP6230dn";
            printDocument2.DocumentName = "file.pdf";
            printDocument2.PrinterSettings.PrintFileName = "file.pdf";
            printDocument2.PrintController = new StandardPrintController();
            printDocument2.Print();


        }

        
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            System.Drawing.Image img = System.Drawing.Image.FromFile(projectDirectory + "\\resource" + "\\back-img.jpg");
            //System.Diagnostics.Debug.WriteLine("i am bangladesh:  "+i);

            var dateTime = DateTime.Now;  

            String convertedDate = dateTime.ToLongDateString();
            SfBarcode barcode = new SfBarcode();
            barcode.Text = a4Printers[i].cn_number;
            barcode.SymbologySettings = code128ASetting;
            barcode.Symbology = BarcodeSymbolType.Code128A;
            barcode.DisplayText = true;
            barcode.Size = new Size(100,40);
            Image barCodeimage = barcode.ToImage(barcode.Size);


            int topDisplacement = 0;
            int topAdjustMent = 60;
            for (int j = 0; j < 3; j++)
            {
                string fontName = "Arial";
                int fontSize = 9;
                FontStyle fontStyle = FontStyle.Bold;

                int topPanelleft1 = 200;
                int TopPaneltop1 = 40 + topDisplacement;
                int topPanellineGape = 18;

                // Uppur Information 

                e.Graphics.DrawString(convertedDate, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1 - 100, TopPaneltop1));
                e.Graphics.DrawString(a4Printers[i].sender_reference, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1 - 100, TopPaneltop1 + topPanellineGape));
                e.Graphics.DrawString(a4Printers[i].sender_branch_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1 - 40, TopPaneltop1 + topPanellineGape * 2));
                e.Graphics.DrawString(a4Printers[i].receiver_branch_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1, TopPaneltop1 + topPanellineGape * 3 + 1));

                int topPanellineGape2 = 26;
                topPanelleft1 = 420;
                int adjustTop1 = 2;
                e.Graphics.DrawString(a4Printers[i].service_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1, TopPaneltop1 - adjustTop1 - 3));
                e.Graphics.DrawString(a4Printers[i].is_home_delivery, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1, TopPaneltop1 - adjustTop1 + topPanellineGape2));
                e.Graphics.DrawString(a4Printers[i].condition_amount, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(topPanelleft1, TopPaneltop1 - adjustTop1 + topPanellineGape2 * 2));


                // BarCode 

                e.Graphics.DrawImage(barCodeimage, new Rectangle(topPanelleft1 + 140, TopPaneltop1 + 85, 200, 70));
              //  System.Diagnostics.Debug.WriteLine("output: " + (TopPaneltop1 + 85) + " " + (topPanelleft1 + 140) + " " + j);




                int senderleft1 = 153;
                int sendertop1 = topDisplacement + 205 - topAdjustMent;
                int lineGape = 16;

                // sender information 

                e.Graphics.DrawString(a4Printers[i].sender_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(senderleft1, sendertop1));
                e.Graphics.DrawString(a4Printers[i].sender_contact_no, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(senderleft1, sendertop1 + lineGape));
                e.Graphics.DrawString(a4Printers[i].sender_address, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(senderleft1, sendertop1 + lineGape * 2));

                // reciver information 
                senderleft1 = 395;
                e.Graphics.DrawString(a4Printers[i].receiver_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(senderleft1, sendertop1 - 6));
                e.Graphics.DrawString(a4Printers[i].receiver_contact_no, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(senderleft1, sendertop1 + lineGape - 5));
                e.Graphics.DrawString(a4Printers[i].receiver_address, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(senderleft1, sendertop1 + lineGape * 2 - 3));

                // Product Description 
                int productTop1 = topDisplacement + 300 - topAdjustMent;
                int productLeft = 150;
                e.Graphics.DrawString(a4Printers[i].items, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft, productTop1));
                e.Graphics.DrawString(a4Printers[i].item_qty, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft + 360, productTop1));
                e.Graphics.DrawString(a4Printers[i].condition_mms_charge, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft + 430, productTop1));
                e.Graphics.DrawString(a4Printers[i].net_amount, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft + 500, productTop1));

                // Booking Officer Information 

                int moneyTop1 = topDisplacement + 342 - topAdjustMent;
                e.Graphics.DrawString(AmountToText.amountToWord(a4Printers[i].net_amount), new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft + 70, moneyTop1));
                e.Graphics.DrawString(a4Printers[i].user_name, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft + 110, moneyTop1 + 24));
                e.Graphics.DrawString(a4Printers[i].created_at, new Font(fontName, fontSize, fontStyle), Brushes.Black, new Point(productLeft + 460, moneyTop1 + 20));

                topDisplacement += 370 - j * 6;
            }

            i = i + 1;



            if (i < a4Printers.Count)
             { 
             e.HasMorePages = true;
             }
            

        }
      


        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void sfBarcode2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}


