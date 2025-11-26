using UnoApp.Services;
using UnoApp.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace UnoApp.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        // Đăng ký sự kiện khi trang được tải xong
        this.Loaded += MainPage_Loaded;
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        // Tự động tải dữ liệu khi mở màn hình
        await LoadData();
    }

    private async void ReloadButton_Click(object sender, RoutedEventArgs e)
    {
        // Tải lại khi bấm nút
        await LoadData();
    }

    // Hàm xử lý logic tải dữ liệu từ API
    private async Task LoadData()
    {
        try
        {
            // Kiểm tra null để tránh lỗi khi chuyển trang quá nhanh
            if (StatusText == null) return;

            StatusText.Text = "⏳ Đang gọi API...";
            StatusText.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Orange);

            // Gọi API lấy danh sách sản phẩm (Trả về ApiResponse<List<Product>>)
            var response = await ApiService.Client.GetProductsAsync();

            // Kiểm tra kết quả trả về
            if (response.IsSuccess && response.Data != null)
            {
                var products = response.Data;

                // Đổ dữ liệu vào ListView
                if (ProductList != null)
                {
                    ProductList.ItemsSource = products;
                }

                StatusText.Text = $"✅ Tải xong {products.Count} sản phẩm";
                StatusText.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Green);
            }
            else
            {
                StatusText.Text = $"⚠️ Lỗi Backend: {response.Message}";
                StatusText.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
            }
        }
        catch (Exception ex)
        {
            if (StatusText != null)
            {
                StatusText.Text = $"❌ Lỗi kết nối: {ex.Message}";
                StatusText.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
            }
            // In lỗi ra cửa sổ Output để debug
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

    // Hàm xử lý khi bấm vào một dòng trong danh sách sản phẩm
    private void ProductList_ItemClick(object sender, ItemClickEventArgs e)
    {
        // Lấy sản phẩm vừa được bấm (ép kiểu về Product)
        if (e.ClickedItem is Product clickedProduct)
        {
            // Chuyển sang trang Chi Tiết và gửi kèm dữ liệu sản phẩm đó
            Frame.Navigate(typeof(ProductDetailPage), clickedProduct);
        }
    }
}
