using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Voude.Models;

namespace Voude.Models
{
    [Serializable]
    public class CartItem
    {
        VOUCHER voucher;
        int quantity;

        public CartItem(VOUCHER voucher, int quantity)
        {
            this.voucher = voucher;
            this.quantity = quantity;
        }

        public VOUCHER Voucher { get => voucher; set => voucher = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
    public class Cart
    {
        List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(VOUCHER voucher, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Voucher.id == voucher.id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem(voucher, quantity));
            }
            else
            {
                line.Quantity += quantity;

            }

        }
        public void IncreaseItem(int id)
        {
            CartItem line = lineCollection
                .Where(p => p.Voucher.id == id)
                .FirstOrDefault();

            if (line == null)
            {
                //lineCollection.Add(new CartItem(voucher, quantity));
            }
            else
            {
                line.Quantity++;

            }

        }
        public void DecreaseItem(int id)
        {
            CartItem line = lineCollection
                .Where(p => p.Voucher.id == id)
                .FirstOrDefault();

            if (line == null)
            {
                //lineCollection.Add(new CartItem(voucher, quantity));
            }
            else
            {
                if (line.Quantity > 0)
                {
                    line.Quantity--;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.Voucher.id ==id);
                }


            }

        }
        public void UpdateItem(VOUCHER vc, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Voucher.id == vc.id)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.Voucher.id == vc.id);
                }
            }
        }




        public void RemoveLine(VOUCHER voucher)
        {
            lineCollection.RemoveAll(l => l.Voucher.id == voucher.id);
        }
        public int? ComputeTotalValue()
        {
            return lineCollection.Sum(e => System.Convert.ToInt32(e.Voucher.price) * e.Quantity);

        }
        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}