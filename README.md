# FreshFruit

Aplikasi penjual buah sederhana

# Fungsionalitas

Pengguna memasukkan buah kedalam keranjang. Lalu aplikasi akan menghitung secara otomatis dan menentukan apakah keranjang penuh atau masih bisa diisi

# Diagram

![Diagram](https://user-images.githubusercontent.com/20190165/99427613-3809b600-2938-11eb-9aee-9d1d8ed3a369.JPG)

# Logika

          Seller fikri;

                  public MainWindow()
                  {
                      InitializeComponent();

                      Bucket keranjangBuah = new Bucket(2);
                      BucketController bucketController = new BucketController(keranjangBuah, this);

                      fikri = new Seller("fikri", bucketController);

                      ListBoxBucket.ItemsSource = keranjangBuah.findAll();
                  }
                  
Penginstansian seller fikri yg diambil dari seller.cs untuk diberikan kewenangan untuk mengontrol keranjang dan diisi buah

    class Seller
    {
        private string name;
        private BucketController bucket;

        public Seller(string name, BucketController bucket)
        {
            this.name = name;
            this.bucket = bucket;
        }

        public List<Fruit> findAll()
        {
            return this.bucket.findAll();
        }

        public void addFruit(Fruit fruit)
        {
            this.bucket.addFruit(fruit);
        }

Pada seller.cs ini berisi pendeklarasian seller secara public yang dapat mengakses BucketController serta berisi list findAll() yang mengakses dari keranjang. Serta penambahan buah pada keranjang.

class Bucket
    {
        private int capacity;
        private List<Fruit> fruits;

        public Bucket(int capacity)
        {
            this.capacity = capacity;
            this.fruits = new List<Fruit>();
        }
        public void insert(Fruit fruit)
        {
            this.fruits.Add(fruit);
        }
        public void remove(int position)
        {
            this.fruits.RemoveAt(position);
        }
        public List<Fruit> findAll()
        {
            return this.fruits;
        }

        public int getCapacity()
        {
            return this.capacity;
        }
        public int countItems()
        {
            return this.fruits.Count();
        }
    }
    
Pada class bucket.cs berisi pendeklarasian list findAll() untuk dimunculkan pada jendela. Juga insert (penambahan item) remove (penghapusan item) pengambilan data dari capacity serta penghitungan item yang bersambung dengan class fruits.cs.

    interface BucketEventListener
    {
        void onSucceed(string message);
        void onFailed(string message);
    }
    
Nah untuk interface dan class dari BucketEventListener sendiri berfungsi menghandle dari proses pada keranjang untuk menentukan berhasil atau tidaknya suatu proses.

class BucketController
    {
        private Bucket bucket;
        private BucketEventListener eventListener;

        public BucketController(Bucket bucket, BucketEventListener eventListener)
        {
            this.bucket = bucket;
            this.eventListener = eventListener;
        }
        public void addFruit(Fruit fruit)
        {
            if (bucketIsOverload())
            {
                eventListener.onFailed("Ops, keranjang penuh");
            }
            else
            {
                this.bucket.insert(fruit);
                eventListener.onSucceed("Yey, berhasil ditambahkan");
            }
        }
        public bool bucketIsOverload()
        {
            return bucket.countItems() >= bucket.getCapacity();
        }

        public void removeFruit(Fruit fruit)
        {
            for (int itemPosition = 0; itemPosition < bucket.countItems(); itemPosition++)
            {
                if (bucket.findAll().ElementAt(itemPosition).getName() == fruit.name)
                {
                    bucket.remove(itemPosition);
                    eventListener.onSucceed("Yey, berhasil dihapus");
                }
            }
        }
        public List<Fruit> findAll()
        {
            return this.bucket.findAll();
        }
    }
    
untuk BucketController.cs sendiri sebagai pengendali dari keranjang pada jendela. Berfungsi untuk menentukan overloadnya keranjang, penambahan, penghapusan, serta menampikan notifikasi pada layar
