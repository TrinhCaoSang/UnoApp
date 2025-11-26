using UnoApp.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace UnoApp.Presentation
{
    public sealed partial class ProductDetailPage : Page
    {
        private Product _currentProduct;

        public ProductDetailPage()
        {
            this.InitializeComponent();
        }

        // Hàm này chạy tự động khi trang được mở ra (hứng dữ liệu)
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Lấy cục dữ liệu được gửi sang
            if (e.Parameter is Product product)
            {
                _currentProduct = product;

                // Gán dữ liệu lên màn hình
                NameText.Text = product.Name;
                PriceText.Text = $"{product.Price:N0} đ"; // Format tiền đẹp
                BarcodeText.Text = product.Barcode;
                UnitText.Text = product.Unit;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Quay lại trang trước
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            // Hiện thông báo đã thêm
            var dialog = new ContentDialog
            {
                Title = "Giỏ hàng",
                Content = $"Đã thêm '{_currentProduct.Name}' vào giỏ hàng!",
                CloseButtonText = "Tiếp tục mua sắm",
                XamlRoot = this.XamlRoot
            };
            await dialog.ShowAsync();
        }
    }
}
