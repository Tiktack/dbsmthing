using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public static class Logic
    {
        public static offers getBooks(string path = @"c:\Storage\1.xml")
        {

            var reader = new StreamReader(path);
            var doc = XElement.Parse(reader.ReadToEnd()).Element("shop").Element("offers");
            var readerNew = new MemoryStream(Encoding.UTF8.GetBytes(doc.ToString()));

            var serializer = new XmlSerializer(typeof(offers));

            return (offers)serializer.Deserialize(readerNew);
        }
        //public static IEnumerable<T> getSmthing<T>(offers offers) where T : IDictionaries, new()
        //{
        //    return offers.offer.Select(x => x.author).Distinct().Select(x => new T { name = x });
        //}
        public static IEnumerable<Author> GetAuthors(offers offers)
        {
            return offers.offer.Select(x => x.author).Distinct().Select(x => new Author { name = x });
        }
        public static IEnumerable<Language> GetLanguages(offers offers)
        {
            return offers.offer.Select(x => x.language).Distinct().Select(x => new Language { name = x });
        }
        public static IEnumerable<Sales_note> GetSales_note(offers offers)
        {
            return offers.offer.Select(x => x.sales_notes).Distinct().Select(x => new Sales_note { name = x });
        }
        public static IEnumerable<Publisher> GetPublishers(offers offers)
        {
            return offers.offer.Select(x => x.publisher).Distinct().Select(x => new Publisher { name = x });
        }
        public static IEnumerable<Series> GetSeries(offers offers)
        {
            return offers.offer.Select(x => x.series).Distinct().Select(x => new Series { name = x });
        }

        public static IEnumerable<Book> ConvertOffersToBooks(offers offers, BookContext context)
        {

            var result = offers.offer.Select(x =>
            {
                return new Book
                {
                    url = x.url,
                    price = x.price,
                    oldprice = x.oldprice,
                    currencyId = x.currencyId,
                    categoryId = (int)x.categoryId,
                    picture = new List<Picture>(x.picture.Select(t => new Picture { pictureUrl = t })),
                    store = x.store,
                    pickup = x.pickup,
                    delivery = x.delivery,
                    local_delivery_cost = x.local_delivery_cost,
                    Author = context.Authors.FirstOrDefault(t => t.name == x.author),
                    name = x.name,
                    publisher = context.Publishers.FirstOrDefault(t => t.name == x.publisher),
                    series = context.Series.FirstOrDefault(t => t.name == x.series),
                    year = x.year,
                    iSBN = x.ISBN,
                    language = context.Languages.FirstOrDefault(t => t.name == x.language),
                    binding = x.binding,
                    page_extent = x.page_extent,
                    description = x.description,
                    sales_notes = context.Sales_Notes.FirstOrDefault(t => t.name == x.sales_notes),
                    manufacturer_warranty = x.manufacturer_warranty,
                    barcode = x.barcode,
                    weight = x.weight,
                    dimensions = x.dimensions,
                    available = x.available,
                    type = x.type,
                    group_id = (int)x.group_id,
                    _params = new List<Param>(x.param.Select(t => new Param { paramName = t.name, paramUnit = t.unit, paramValue = t.Value }))
                };
            });
            return result;
        }
    }


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class offers
    {

        private offersOffer[] offerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("offer")]
        public offersOffer[] offer
        {
            get
            {
                return this.offerField;
            }
            set
            {
                this.offerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class offersOffer
    {

        private string urlField;

        private double priceField;

        private double oldpriceField;

        private bool oldpriceFieldSpecified;

        private string currencyIdField;

        private uint categoryIdField;

        private string[] pictureField;

        private bool storeField;

        private bool pickupField;

        private bool deliveryField;

        private uint local_delivery_costField;

        private string authorField;

        private string nameField;

        private string publisherField;

        private string seriesField;

        private string yearField;

        private string iSBNField;

        private string languageField;

        private string bindingField;

        private string page_extentField;

        private string descriptionField;

        private string sales_notesField;

        private bool manufacturer_warrantyField;

        private offersOfferAge ageField;

        private ulong barcodeField;

        private decimal weightField;

        private string dimensionsField;

        private offersOfferParam[] paramField;

        private uint idField;

        private bool availableField;

        private string typeField;

        private uint group_idField;

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public double price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public double oldprice
        {
            get
            {
                return this.oldpriceField;
            }
            set
            {
                this.oldpriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool oldpriceSpecified
        {
            get
            {
                return this.oldpriceFieldSpecified;
            }
            set
            {
                this.oldpriceFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string currencyId
        {
            get
            {
                return this.currencyIdField;
            }
            set
            {
                this.currencyIdField = value;
            }
        }

        /// <remarks/>
        public uint categoryId
        {
            get
            {
                return this.categoryIdField;
            }
            set
            {
                this.categoryIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("picture")]
        public string[] picture
        {
            get
            {
                return this.pictureField;
            }
            set
            {
                this.pictureField = value;
            }
        }

        /// <remarks/>
        public bool store
        {
            get
            {
                return this.storeField;
            }
            set
            {
                this.storeField = value;
            }
        }

        /// <remarks/>
        public bool pickup
        {
            get
            {
                return this.pickupField;
            }
            set
            {
                this.pickupField = value;
            }
        }

        /// <remarks/>
        public bool delivery
        {
            get
            {
                return this.deliveryField;
            }
            set
            {
                this.deliveryField = value;
            }
        }

        /// <remarks/>
        public uint local_delivery_cost
        {
            get
            {
                return this.local_delivery_costField;
            }
            set
            {
                this.local_delivery_costField = value;
            }
        }

        /// <remarks/>
        public string author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string publisher
        {
            get
            {
                return this.publisherField;
            }
            set
            {
                this.publisherField = value;
            }
        }

        /// <remarks/>
        public string series
        {
            get
            {
                return this.seriesField;
            }
            set
            {
                this.seriesField = value;
            }
        }

        /// <remarks/>
        public string year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        public string ISBN
        {
            get
            {
                return this.iSBNField;
            }
            set
            {
                this.iSBNField = value;
            }
        }

        /// <remarks/>
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string binding
        {
            get
            {
                return this.bindingField;
            }
            set
            {
                this.bindingField = value;
            }
        }

        /// <remarks/>
        public string page_extent
        {
            get
            {
                return this.page_extentField;
            }
            set
            {
                this.page_extentField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string sales_notes
        {
            get
            {
                return this.sales_notesField;
            }
            set
            {
                this.sales_notesField = value;
            }
        }

        /// <remarks/>
        public bool manufacturer_warranty
        {
            get
            {
                return this.manufacturer_warrantyField;
            }
            set
            {
                this.manufacturer_warrantyField = value;
            }
        }

        /// <remarks/>
        public offersOfferAge age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        public ulong barcode
        {
            get
            {
                return this.barcodeField;
            }
            set
            {
                this.barcodeField = value;
            }
        }

        /// <remarks/>
        public decimal weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string dimensions
        {
            get
            {
                return this.dimensionsField;
            }
            set
            {
                this.dimensionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("param")]
        public offersOfferParam[] param
        {
            get
            {
                return this.paramField;
            }
            set
            {
                this.paramField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool available
        {
            get
            {
                return this.availableField;
            }
            set
            {
                this.availableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint group_id
        {
            get
            {
                return this.group_idField;
            }
            set
            {
                this.group_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class offersOfferAge
    {

        private string unitField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class offersOfferParam
    {

        private string nameField;

        private string unitField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
