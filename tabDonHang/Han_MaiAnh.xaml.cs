using System;
using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using tabDonHang.Phân_Loại_Khách_Hàng;
using tabDonHang.Sản_phẩm;
using tabDonHang.Đọc__Ghi_File;
using System.Data;
using System.ComponentModel;
using tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết;
using LiveCharts;
using LiveCharts.Wpf;

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for Han_MaiAnh.xaml
    /// </summary>
    //Hân + Mai Anh

    public partial class Han_MaiAnh : Window
    {
        MangHoaDon mangHoaDon = new MangHoaDon();
        MangKhachHang mangKhachHang = new MangKhachHang();
        Load_DSKhachHang load_dsKH = new Load_DSKhachHang();
        List<HoaDon> ListHoaDon = new List<HoaDon>();
        List<KhachHang> ListKhachHang = new List<KhachHang>();
        DocFile docFileDonHang = new DocFile();
        HoaDon HD = new HoaDon();
        List<SanPham> listhangban = new List<SanPham>();

        
        MangTenSP mangSp = new MangTenSP();
        List<SanPham> ListSP = new List<SanPham>();
        string text = "",text2="";
        List<SanPham> List_lboSP = new List<SanPham>();

        
        public CmangNCC mangNCC = new CmangNCC();
        List<CNhacungcap> listtab2 = new List<CNhacungcap>();

        
        CmangBCDT tapBCDT = new CmangBCDT();
        List<CbaocaoDT> Listbaocao = new List<CbaocaoDT>();

        Func<ChartPoint, string> label = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);



        public Han_MaiAnh()
        {
            InitializeComponent();

            ListHoaDon = docFileDonHang.DocFile_TraVeListHoaDon1("DonHang1.txt");
            LsvDSHoaDon.ItemsSource = ListHoaDon;
            mangHoaDon = docFileDonHang.DocFile_TraVeMangHoaDon1("DonHang1.txt");

            lblSoDonHang.Content = "There are " + mangHoaDon.LaySoPhanTu().ToString() + " orders";
            ListKhachHang = load_dsKH.LoadDSKH_TraVeItemSource(mangHoaDon);
            LsvKhachHang.ItemsSource = ListKhachHang;
            mangKhachHang = load_dsKH.LoadDSKH_TraVeMangKH(mangHoaDon);

            lblngayMua.Content = DateTime.Now.ToShortDateString();

            //Random Mã Hóa Đơn
            txtMaHD.Content = HD.randomMaHoaDon();
            lblloaiKH.Content = "Normal";
            lblChietKhau.Content = "0%";


            
            DocFile docFileSanPham = new DocFile();
            ListSP = docFileSanPham.DocFile_TraVeListSP("DSSP.txt");
            mangSp = docFileSanPham.DocFile_TraVeMangTenSP("DSSP.txt");
            LsvSanPham.ItemsSource = ListSP;

            
            listchonmuaSP.ItemsSource = ListSP;
            cboChonNCC.ItemsSource = listtab2;
            cboNCC.ItemsSource = listtab2;

            
            mangNCC.docfile("dataNCC.txt");
            mangNCC.doclichsudonhang();
            LsvDSNCC.ItemsSource = null;
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;
            lblSLKhac.Content = mangNCC.demSLNCC("Other");
            lblSLNS.Content = mangNCC.demSLNCC("Book store");
            lblSLNXB.Content = mangNCC.demSLNCC("NXB");

            
            DocFile docFileBaocao = new DocFile();
            docFileBaocao.docfilebaocao("BCDT.txt", Listbaocao, tapBCDT);
            lsvBCDT.ItemsSource = Listbaocao;
            long a = 0, b = 0, c = 0;
            foreach (var item in Listbaocao)
            {
                a += item.SL;
                b += item.DT;
                c += item.LN;
            }
            tbkSL.Text += "\n" + a.ToString();
            tbkDT.Text += "\n" + b.ToString();
            tbkLN.Text += "\n" + c.ToString();
        }

        
        static int KiemTraDuLieu(string A)
        {
            int count = 0;
            foreach (char c in A)
            {
                if (c != ' ')
                    count++;
            }
            if (count > 0)
                return 0;
            else
                return 1;
        }
          

        private void btntaoDonHang_Click(object sender, RoutedEventArgs e)
        {
            HoaDon AB = new HoaDon();
            string phuongThucThanhToan = null;
            if (radtienMat.IsChecked == true)
                phuongThucThanhToan = "Cash";
            if (radchuyenKhoan.IsChecked == true)
                phuongThucThanhToan = "Card";

            
            if (KiemTraDuLieu(txttenKhachHang.Text) == 0 && KiemTraDuLieu(txtsoDienThoai.Text) == 0 && KiemTraDuLieu(txtdiaChi.Text) == 0 && phuongThucThanhToan != null)
            {
                    try
                    {
                        AB.NhapHoaDon1(txtMaHD.Content.ToString(), txttenKhachHang.Text, txtsoDienThoai.Text, txtdiaChi.Text, lblThanhTien.Content.ToString(), DateTime.Now, phuongThucThanhToan, mangKhachHang);
                        mangHoaDon.NhapMangHoaDon(AB);
                     
                        ListHoaDon.Add(AB);
                        LsvDSHoaDon.ItemsSource = null;
                        LsvDSHoaDon.ItemsSource = ListHoaDon;

                        DocFile ghiFile = new DocFile();
                        ghiFile.ghiVaoFileHoaDon("DonHang1.txt", mangHoaDon);
                        mangKhachHang = load_dsKH.LoadDSKH_TraVeMangKH(mangHoaDon);
                        ListKhachHang = load_dsKH.LoadDSKH_TraVeItemSource(mangHoaDon);
                        LsvKhachHang.ItemsSource = ListKhachHang;
                    

                    tapBCDT.suaBCDT(listhangban, mangSp, Listbaocao, AB);
                    lsvBCDT.ItemsSource = null;
                    lsvBCDT.ItemsSource = Listbaocao;
                    long a = 0, b = 0, c = 0;
                    foreach (var item in Listbaocao)
                    {
                        a += item.SL;
                        b += item.DT;
                        c += item.LN;
                    }
                    tbkSL.Text =  a.ToString();
                    tbkDT.Text = b.ToString();
                    tbkLN.Text = c.ToString();
                    tapBCDT.luuBCDT("BCDT.txt");
                    MessageBox.Show("Order successfully created", "", MessageBoxButton.OK);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }

                
                foreach (var item in mangSp.ListSPham)
                {
                    if (item.SLBan > 0)
                    {
                        item.SoLuongBan += item.SLBan;
                        item.SoLuongTon = item.SoLuongNhap - item.SoLuongBan;
                        item.SLBan = 0;
                    }
                }
                mangSp.capnhatmang();
                LsvSanPham.ItemsSource = null;
                LsvSanPham.ItemsSource = mangSp.ListSPham;
                DocFile tam = new DocFile();
                tam.ghiVaoFileSanPham("DSSP.txt", mangSp);
                lblSoDonHang.Content = "There are " + mangHoaDon.LaySoPhanTu().ToString() + " orders";
                    txttenKhachHang.Text = "";
                    txtsoDienThoai.Text = "";
                    txtsoDienThoai.Text = "";
                    txtdiaChi.Text = "";
                    lblThanhTien.Content = "0";
                lblChietKhau.Content = "0%";
                lblloaiKH.Content = "Normal";
                     listchonmuaSP.SelectedIndex = -1;
                    radtienMat.IsChecked = false;
                    radchuyenKhoan.IsChecked = false;
                    listhangban.Clear();
                    LsvDSMua.ItemsSource= null;
                    docFileDonHang.DocFile_TraVeMangHoaDon1("DonHang1.txt");
                    txtMaHD.Content = HD.randomMaHoaDon();
            }
            else
                MessageBox.Show("Please fill in all required information");
        }
         
        static string[] TachChuoi(string A)
        {
            string[] B = A.Split('_');
            return B;
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            int i, count = 0;
            List<HoaDon> hoaDonSearch = new List<HoaDon>();
            if (txtSearch.Text.Trim() != "")
            {
                if (mangHoaDon.LaySoPhanTu() != 0)
                {
                    for (i = 0; i < mangHoaDon.LaySoPhanTu(); i++)
                    {
                        if (mangHoaDon.HDon[i].SoDienThoai == txtSearch.Text)
                        {
                            hoaDonSearch.Add(mangHoaDon.HDon[i]);
                            count++;
                        }

                    }
                    if (count == 0)
                        MessageBox.Show("Order does not exist");
                    else
                        LsvDSHoaDon.ItemsSource = hoaDonSearch;
                }
                else
                    MessageBox.Show("Order does not exist");
            }
        }
        private void btnHuyTimKiem_Click(object sender, RoutedEventArgs e)
        {
            LsvDSHoaDon.ItemsSource = null;
            LsvDSHoaDon.ItemsSource = ListHoaDon;
            txtSearch.Text = "";
        }



        private void btnXuatHoaDon_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelHoaDon xuat = new XuatExcelHoaDon();
            xuat.xuatExcelHoaDon(ListHoaDon);
        }

        private void BtnXuatDS_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelDanhSachKhachHang xuat = new XuatExcelDanhSachKhachHang();
            xuat.xuatExcelDSKH(ListKhachHang);
        }

        private void btnTao_Click(object sender, RoutedEventArgs e)
        {
            SanPham S = new SanPham();
            DocFile docFile = new DocFile();
            if (KiemTraDuLieu(txtTenSanPham.Text) == 0 && KiemTraDuLieu(txtMaSp.Text) == 0 && KiemTraDuLieu(txtGiaBan.Text) == 0 && KiemTraDuLieu(txtGiaGoc.Text) == 0 && KiemTraDuLieu(text) == 0)
            {
                if (mangNCC.KiemtraMaNCC(text) == true)
                {
                    try
                    {
                        S.NhapSanPham(txtTenSanPham.Text, txtMaSp.Text, txtGiaGoc.Text, txtGiaBan.Text, text, txtImg_Internet.Text);

                        mangSp.NhapMangSP(S);
                        ListSP.Add(S);
                        LsvSanPham.ItemsSource = null;
                        LsvSanPham.ItemsSource = ListSP;

                        docFile.ghiVaoFileSanPham("DSSP.txt", mangSp);
                        listchonmuaSP.ItemsSource = null;
                        listchonmuaSP.ItemsSource = ListSP;

                        MessageBox.Show("Successfully added", "", MessageBoxButton.OK);
                        txtTenSanPham.Text = "";
                        txtMaSp.Text = "";
                        txtGiaGoc.Text = "";
                        txtGiaBan.Text = "";
                        cboNCC.Text = "";
                        text = "";
                        txtImg_Internet.Text = "";
                        Img.Source = null;
                    }
                    catch
                    {
                        MessageBox.Show("Please check the input");
                    }
                    DocFile doc = new DocFile();
                }
                else
                    MessageBox.Show("This supplier ID does not exist", "", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Please fill in all required information");
        }

        


        private void btnXuat_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelDanhSachSanPham xuat = new XuatExcelDanhSachSanPham();
            xuat.xuatExcelDSSP_Nhap(ListSP);
        }


        private void btnTimKiemKH_Click(object sender, RoutedEventArgs e)
        {
            int i, count = 0;
            List<KhachHang> khachHangSearch = new List<KhachHang>();
            if (txtTimKiem.Text.Trim() != "")
            {
                if (mangKhachHang.spt != 0)
                {
                    for (i = 0; i < mangKhachHang.spt; i++)
                    {
                        if (mangKhachHang.khachHang[i].SoDienThoai == txtTimKiem.Text)
                        {
                            khachHangSearch.Add(mangKhachHang.khachHang[i]);
                            count++;
                        }

                    }
                    if (count == 0)
                        MessageBox.Show("Customer does not exist");
                    else
                        LsvKhachHang.ItemsSource = khachHangSearch;
                }
                else
                    MessageBox.Show("Customer does not exist");
            }
        }


        private void btnHuyTimKiemKH_Click(object sender, RoutedEventArgs e)
        {
            LsvKhachHang.ItemsSource = null;
            LsvKhachHang.ItemsSource = ListKhachHang;
            txtTimKiem.Text = "";
        }


        private void btnLuuNCC_Click(object sender, RoutedEventArgs e)
        {
            CNhacungcap NCC = new CNhacungcap();
            if (KiemTraDuLieu(txtNhapTen.Text) == 0 && KiemTraDuLieu(txtNhapEmail.Text) == 0 && KiemTraDuLieu(txtNhapEmail.Text) == 0 && KiemTraDuLieu(txtNhapDiaChi.Text) == 0 && KiemTraDuLieu(txtNhapSDT.Text) == 0 && KiemTraDuLieu(txtNhapNV.Text) == 0 && KiemTraDuLieu(txtNhapWeb.Text) == 0 && cboNhomNCC.Text != "Select group" && cboGiaMacDinh.Text != "Select default price" && cboHTTT.Text != "Select payment method" && cboThue.Text != "Select default tax")
            {
                if (mangNCC.KiemtraMaNCC(txtNhapMa.Text) == false)
                {
                    NCC.NhapNCC(txtNhapMa.Text, txtNhapTen.Text, cboNhomNCC.Text, txtNhapEmail.Text, txtNhapSDT.Text, "Partner");
                    NCC.DiaChi = txtNhapDiaChi.Text;
                    NCC.NhanVien = txtNhapNV.Text;
                    NCC.Website = txtNhapWeb.Text;
                    NCC.ThueMD = cboThue.Text;
                    NCC.GiaMD = cboGiaMacDinh.Text;
                    NCC.HTTT = cboHTTT.Text;
                    NCC.NhomNCC = cboNhomNCC.Text;
                    mangNCC.nhapmangncc(NCC);
                    mangNCC.luulichsudonhang();
                    LsvDSNCC.ItemsSource = null;
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    MessageBox.Show("Successfully added", "", MessageBoxButton.OK);

                 
                    //nhapCBO(cbo);
                    cboChonNCC.ItemsSource = null;
                    cboChonNCC.ItemsSource = listtab2;

                    mangNCC.capnhatfile("dataNCC.txt");

                    txtNhapTen.Clear();
                    txtNhapMa.Clear();
                    txtNhapEmail.Clear();
                    txtNhapDiaChi.Clear();
                    txtNhapNV.Clear();
                    txtNhapWeb.Clear();
                    txtNhapSDT.Clear();
                    txtImg_Internet.Clear();

                    cboNhomNCC.Text = "Select group";
                    cboHTTT.Text = "Select payment method";
                    cboGiaMacDinh.Text = "Select default price";
                    cboThue.Text = "Select default tax";

                    lblSLKhac.Content = mangNCC.demSLNCC("Other");
                    lblSLNS.Content = mangNCC.demSLNCC("Book store");
                    lblSLNXB.Content = mangNCC.demSLNCC("NXB");
                }
                else
                    MessageBox.Show("This supplier already exists", "", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Please fill in all required information");
        }


        private void btnHuyNCC_Click(object sender, RoutedEventArgs e)
        {
            txtNhapTen.Clear();
            txtNhapMa.Clear();
            txtNhapEmail.Clear();
            txtNhapDiaChi.Clear();
            txtNhapNV.Clear();
            txtNhapWeb.Clear();
            txtNhapSDT.Clear();
        }

        private void LsvDSNCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                CNhacungcap NCC = e.AddedItems[0] as CNhacungcap;
                DetailInfo.IsSelected = true;
                lblTenNCC.Content = NCC.TenNCC;
                txt_TTNCC_Nhom.Text = NCC.NhomNCC;
                txt_TTNCC_Ma.Text = NCC.MaNCC;
                txt_TTNCC_sdt.Text = NCC.SDTNCC;
                txt_TTNCC_Email1.Text = NCC.EmailNCC;
                txt_TTNCC_DiaChi.Text = NCC.DiaChi;
                txt_TTNCC_NVien1.Text = NCC.NhanVien;
                txt_TTNCC_Website.Text = NCC.Website;
                txt_TTNCC_ThueMacDinh.Text = NCC.ThueMD;
                txt_TTNCC_GiaMD.Text = NCC.GiaMD;
                txt_TTNCC_HTTT.Text = NCC.HTTT;
                LsvLichsu.ItemsSource = null;
                LsvLichsu.ItemsSource = mangNCC.timkiemlichsu(NCC.MaNCC);

            }
            catch (Exception ee)
            {

            }

        }

        private void btnSearch_TT_Click(object sender, RoutedEventArgs e)
        {
            mangNCC.spt = listtab2.Count;
            mangNCC.nhapmang(listtab2);
            if (mangNCC.timkiemtheoMa(txtSearch_TT.Text) == true)
                LsvDSNCC.ItemsSource = mangNCC.ListNCC;
            else if (mangNCC.timkiemtheoMa(txtSearch_TT.Text) == false)
                MessageBox.Show("This supplier does not exist", "", MessageBoxButton.OK);
            txtSearch_TT.Clear();
        }

        private void btnhuytim_Click(object sender, RoutedEventArgs e)
        {
            mangNCC.spt = listtab2.Count;
            mangNCC.nhapmang(listtab2);
            LsvDSNCC.ItemsSource = null;
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;
            cboThaotac.Text = "Sort by group";
        }

        private void cboThaotac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mangNCC.spt = listtab2.Count;
            mangNCC.nhapmang(listtab2);
            switch (cboThaotac.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    mangNCC.Loc("NXB");
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    break;
                case 2:
                    mangNCC.Loc("Book store");
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    break;
                case 3:
                    mangNCC.Loc("Other");
                    LsvDSNCC.ItemsSource = mangNCC.ListNCC;
                    break;
            }
        }

        private void btnXuatFile_Click(object sender, RoutedEventArgs e)
        {
            mangNCC.xuatfile();

        }


        private void btnXuaBCDT_Click(object sender, RoutedEventArgs e)
        {
            XuatExcelBaocaoDT xuatbaocao = new XuatExcelBaocaoDT();
            xuatbaocao.luuexcel(Listbaocao);
        }
        private void gvchSL_Click(object sender, RoutedEventArgs e)
        {
            lsvBCDT.ItemsSource = tapBCDT.sxBCDTtheoSL();
        }

        private void gvchDT_Click(object sender, RoutedEventArgs e)
        {
            lsvBCDT.ItemsSource = tapBCDT.sxBCDTtheoDT();
        }

        private void gvcgLN_Click(object sender, RoutedEventArgs e)
        {
            lsvBCDT.ItemsSource = tapBCDT.sxBCDTtheoLN();
        }
        private void btnTimKiemBC_Click(object sender, RoutedEventArgs e)
        {
            List<CbaocaoDT> BCDTSearch = new List<CbaocaoDT>();
            foreach (var item in Listbaocao)
            {
                if (txtSKU.Text == item.SKU)
                    BCDTSearch.Add(item);
            }
            if (BCDTSearch.Count == 0)
                MessageBox.Show("This information does not exist");
            else lsvBCDT.ItemsSource = BCDTSearch;
        }

        private void btnHuyTimKiemBC_Click(object sender, RoutedEventArgs e)
        {
            txtSKU.Text = "";
            lsvBCDT.ItemsSource = null;
            lsvBCDT.ItemsSource = Listbaocao;
        }

        

        

        private void listboxSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            long tongtien = long.Parse(tbkTongtien.Text);
            if (listboxSP.SelectedIndex != -1)
            {
                var selected = listboxSP.SelectedValue as SanPham;
                string text= selected.TenSanPham;
                for (int i = 0; i < mangSp.spt; i++)
                {
                    if (mangSp.ListSPham[i].TenSanPham == text)
                    {
                        using (FormNhapHang form = new FormNhapHang())
                        {
                            form.LaySLTonKho(mangSp.ListSPham[i].SoLuongTon);
                            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                mangSp.ListSPham[i].SLNhap += form.SL;
                                mangSp.ListSPham[i].ThanhTien = form.SL * mangSp.ListSPham[i].GiaGoc;
                                tongtien += mangSp.ListSPham[i].ThanhTien;
                                LsvDSNhapKho.Items.Add(mangSp.ListSPham[i]);
                                mangSp.capnhatmang();
                            }
                        }

                    }
                }
            }
            tbkTongtien.Text = tongtien.ToString();
        }


        private void btntabNhapHang_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (var item in mangSp.ListSPham)
            {
                if (item.SLNhap > 0)
                {
                    item.SoLuongNhap += item.SLNhap;
                    item.SoLuongTon = item.SoLuongNhap - item.SoLuongBan;
                    item.SLNhap = 0;
                }
            }
            LsvSanPham.ItemsSource = null;
            LsvSanPham.ItemsSource = mangSp.ListSPham; ;
            LichSuNhapHang lsu = new LichSuNhapHang();
            lsu.CapNhatLichSu(txtMaDon.Text,tbkTongtien.Text, DateTime.Now);
            foreach(var item in mangNCC.ListNCC)
            {
                if(item.TenNCC == text2)
                {
                    item.History.nhapmangLichSu(lsu);
                }    
            }    
            MessageBox.Show("Successfully imported", "", MessageBoxButton.OK);
            mangNCC.luulichsudonhang();
            DocFile tam = new DocFile();
            tam.ghiVaoFileSanPham("DSSP.txt", mangSp);
            LsvDSNhapKho.Items.Clear();
            txtMaDon.Text = "";
            tbkTongtien.Text = "0";
            listboxSP.SelectedIndex = -1;
            cboChonNCC.SelectedIndex = -1;
            cboChonNCC.IsHitTestVisible = true; cboChonNCC.Focusable = true;
        }

        private void LsvDSNhapKho_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboChonNCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
                listboxSP.ItemsSource = null;
                List_lboSP.Clear();
            //text2 = ((sender as ComboBox)?.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (cboChonNCC.SelectedIndex != -1)
            {
                MessageBox.Show("Please choose only one supplier per import");
                var selected = cboChonNCC.SelectedValue as CNhacungcap;
                text2 = selected.TenNCC;
                int i;
                for (i = 0; i < mangNCC.spt; i++)
                {
                    if (text2 == mangNCC.ListNCC[i].TenNCC)
                    {
                        txtMaDon.Text = mangNCC.ListNCC[i].MaNCC + (mangNCC.ListNCC[i].History.spt + 1);
                        if (mangNCC.ListNCC[i].HTTT == "Card")
                            radCK.IsChecked = true;
                        else if (mangNCC.ListNCC[i].HTTT == "Cash")
                            radTM.IsChecked = true;
                        else break;

                    }
                }

                int m;
                for (m = 0; m < mangSp.spt; m++)
                {
                    if (mangSp.spham[m].kiemtrasp(text2))
                    {
                         List_lboSP.Add(mangSp.spham[m]);
                    }
                }                 
                cboChonNCC.IsHitTestVisible = false; cboChonNCC.Focusable = false;

            }
                listboxSP.ItemsSource = List_lboSP;
        }

 
        private void BtnXoaNhom_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (CNhacungcap it in mangNCC.ListNCC)
            {
                if (it.TenNCC == lblTenNCC.Content.ToString())
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure to delete ?", "Notification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        mangNCC.ListNCC.Remove(it);
                        MessageBox.Show("Successfully deleted");
                    }

                        break;
                }
            }
            
            tabNCC1.IsSelected = true;
            mangNCC.spt = mangNCC.ListNCC.Count();
            mangNCC.capnhatfile("dataNCC.txt");
            LsvDSNCC.ItemsSource = null;
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;

            lblSLKhac.Content = mangNCC.demSLNCC("Other");
            lblSLNS.Content = mangNCC.demSLNCC("Book store");
            lblSLNXB.Content = mangNCC.demSLNCC("NXB");
        }

        
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < mangNCC.spt; i++)
            {
                if (mangNCC.ListNCC[i].TenNCC == lblTenNCC.Content.ToString())
                {
                    mangNCC.ListNCC[i].NhomNCC = txt_TTNCC_Nhom.Text;
                    mangNCC.ListNCC[i].MaNCC = txt_TTNCC_Ma.Text;
                    mangNCC.ListNCC[i].SDTNCC = txt_TTNCC_sdt.Text;
                    mangNCC.ListNCC[i].EmailNCC = txt_TTNCC_Email1.Text;
                    mangNCC.ListNCC[i].Website = txt_TTNCC_Website.Text;
                    mangNCC.ListNCC[i].ThueMD = txt_TTNCC_ThueMacDinh.Text;
                    mangNCC.ListNCC[i].GiaMD = txt_TTNCC_GiaMD.Text;
                    mangNCC.ListNCC[i].HTTT = txt_TTNCC_HTTT.Text;
                    mangNCC.ListNCC[i].NhanVien = txt_TTNCC_NVien1.Text;
                    mangNCC.ListNCC[i].DiaChi = txt_TTNCC_DiaChi.Text;
                }
            }

            MessageBox.Show("Successfully added");
            mangNCC.capnhatfile("dataNCC.txt");
            LsvDSNCC.ItemsSource = null;
            LsvDSNCC.ItemsSource = mangNCC.ListNCC;

            lblSLKhac.Content = mangNCC.demSLNCC("Other");
            lblSLNS.Content = mangNCC.demSLNCC("Book store");
            lblSLNXB.Content = mangNCC.demSLNCC("NXB");

        }

        //tab Sản phẩm
        private void cboNCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboNCC.SelectedIndex != -1)
            {
                var selected = cboNCC.SelectedValue as CNhacungcap;
                text = selected.TenNCC;
            }
            //text = ((sender as ComboBox)?.SelectedItem as ComboBoxItem)?.Content.ToString();

        }

        private void listchonmuaSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            long tongtien = long.Parse(lblThanhTien.Content.ToString());
            long tam = 0;
            //string text = ((sender as ListBox)?.SelectedItem as ListBoxItem)?.ToString();
            if (listchonmuaSP.SelectedIndex != -1)
            {
                var selected = listchonmuaSP.SelectedValue as SanPham;
                string text = selected.TenSanPham;
                for (int i = 0; i < mangSp.spt; i++)
                {
                    if (mangSp.ListSPham[i].TenSanPham == text)
                    {
                        if (mangSp.ListSPham[i].SoLuongTon < 1)
                        {
                            MessageBox.Show("Out of stock!");
                            return;
                        }
                        else

                        {
                            using (FormBanHang form = new FormBanHang())
                            {
                                form.LaySLTonKho(mangSp.ListSPham[i].SoLuongTon);
                                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    mangSp.ListSPham[i].SLBan += form.SLBan;
                                    mangSp.ListSPham[i].ThanhTien_Ban = form.SLBan * mangSp.ListSPham[i].GiaBan;
                                    tongtien += mangSp.ListSPham[i].ThanhTien_Ban;
                                    listhangban.Add(mangSp.ListSPham[i]);
                                    mangSp.capnhatmang();
                                    tam = form.SLBan;

                                }
                            }
                        }
                        HD.SPTrongHD(mangSp.ListSPham[i].TenSanPham, mangSp.ListSPham[i].MaSanPham, Convert.ToInt32(tam), mangSp.ListSPham[i].GiaBan);
                    }
                }
            }
            LsvDSMua.ItemsSource = null;
            LsvDSMua.ItemsSource = listhangban;
            lblThanhTien.Content = tongtien * (100 - int.Parse(lblChietKhau.Content.ToString().Split('%')[0])) / 100;
        }

        private void btnCheckSDT_Click(object sender, RoutedEventArgs e)
        {
            int i;
            int count = 0;
            for (i = 0; i < mangKhachHang.spt; i ++)
            {
                if (txtsoDienThoai.Text.Trim() == ListKhachHang[i].SoDienThoai)
                {
                    txttenKhachHang.Text = ListKhachHang[i].TenKhachHang;
                    txtdiaChi.Text = ListKhachHang[i].DiaChi;
                    count++;
                    lblloaiKH.Content = ListKhachHang[i].PhanLoaiKH;
                    lblChietKhau.Content = ListKhachHang[i].XetCK().ToString() + "%";
                }
            }
            if (count == 0)
            { 
                MessageBox.Show("The phone number does not exist, please add new information", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                txttenKhachHang.Clear();
                txtdiaChi.Clear();
                lblloaiKH.Content = "Normal";
                lblChietKhau.Content = "0%";
            }



        }

        private void btnImg_May_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                Img.Source = new BitmapImage(fileUri);
                txtImg_Internet.Text = openFileDialog.FileName;

            }
        }

        private void btnImg_Internet_Click(object sender, RoutedEventArgs e)
        {
            Uri fileUri = new Uri(txtImg_Internet.Text);
            Img.Source = new BitmapImage(fileUri);
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
            Img_Logo.Visibility = Visibility.Visible;
        }
        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
            Img_Logo.Visibility = Visibility.Collapsed;
        }

        private void tabDH_Selected(object sender, RoutedEventArgs e)
        {
            GridDonHang.Visibility = Visibility.Visible;
            GridKhachHang.Visibility = Visibility.Hidden;
            GridSanPham.Visibility = Visibility.Hidden;
            GridNCC.Visibility = Visibility.Hidden;
            GridBaoCao.Visibility = Visibility.Hidden;
        }

        private void tabKH_Selected(object sender, RoutedEventArgs e)
        {
            GridKhachHang.Visibility = Visibility.Visible;
            GridDonHang.Visibility = Visibility.Hidden;
            GridSanPham.Visibility = Visibility.Hidden;
            GridNCC.Visibility = Visibility.Hidden;
            GridBaoCao.Visibility = Visibility.Hidden;
        }

        private void tabSP_Selected(object sender, RoutedEventArgs e)
        {
            GridSanPham.Visibility = Visibility.Visible;
            GridDonHang.Visibility = Visibility.Hidden;
            GridKhachHang.Visibility = Visibility.Hidden;
            GridNCC.Visibility = Visibility.Hidden;
            GridBaoCao.Visibility = Visibility.Hidden;

        }

        private void tabNCC_Selected(object sender, RoutedEventArgs e)
        {
            GridNCC.Visibility = Visibility.Visible;
            GridDonHang.Visibility = Visibility.Hidden;
            GridKhachHang.Visibility = Visibility.Hidden;
            GridSanPham.Visibility = Visibility.Hidden;
            GridBaoCao.Visibility = Visibility.Hidden;
        }

        private void tabBC_Selected(object sender, RoutedEventArgs e)
        {
            GridBaoCao.Visibility = Visibility.Visible;
            GridDonHang.Visibility = Visibility.Hidden;
            GridKhachHang.Visibility = Visibility.Hidden;
            GridSanPham.Visibility = Visibility.Hidden;
            GridNCC.Visibility = Visibility.Hidden;
            SeriesCollection series1 = new SeriesCollection();
            SeriesCollection series2 = new SeriesCollection();
            SeriesCollection series3 = new SeriesCollection();

            foreach (var obj in Listbaocao)
            {
                series1.Add(new PieSeries() { Title = obj.Tensp.ToString(), Values = new ChartValues<long> { obj.DT }, LabelPoint = label });
                series2.Add(new PieSeries() { Title = obj.Tensp.ToString(), Values = new ChartValues<long> { obj.SL }, LabelPoint = label });
                series3.Add(new PieSeries() { Title = obj.Tensp.ToString(), Values = new ChartValues<long> { obj.LN }, LabelPoint = label });

            }
            piechart1.Series = series1;
            piechart2.Series = series2;
            piechart3.Series = series3;
            piechart1.LegendLocation = LegendLocation.Bottom;
            piechart2.LegendLocation = LegendLocation.Bottom;
            piechart3.LegendLocation = LegendLocation.Bottom;
        }

        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbcBC_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }


        private void btnHuyNhapHang_Click(object sender, RoutedEventArgs e)
        {
            txtMaDon.Text = "";
            cboChonNCC.SelectedIndex = -1;
            cboChonNCC.IsHitTestVisible = true; cboChonNCC.Focusable = true;
            listboxSP.SelectedIndex = -1;
            LsvDSNhapKho.Items.Clear();
            tbkTongtien.Text = "0";

        }

        public void laytenuser(string a)
        {
            tbkUserName.Text = "Hello, " + a + "!";
        }

        private void btnHuyTaoDonHang_Click(object sender, RoutedEventArgs e)
        {
            txttenKhachHang.Text = "";
            txtsoDienThoai.Text = "";
            txtsoDienThoai.Text = "";
            txtdiaChi.Text = "";
            lblThanhTien.Content = "0";
            lblChietKhau.Content = "0%";
            lblloaiKH.Content = "Normal";
            listchonmuaSP.SelectedIndex = -1;
            radtienMat.IsChecked = false;
            radchuyenKhoan.IsChecked = false;
            listhangban.Clear();
            LsvDSMua.ItemsSource = null;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure to logout?", "Nofication", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rs == MessageBoxResult.Yes)
            {
                LoginForm loginform = new LoginForm();
                loginform.Show();
                this.Close();
            }
        }
    }
}

