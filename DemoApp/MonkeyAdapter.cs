using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using DemoApp.Shared;
using Android.App;
using Bumptech.Glide;

namespace DemoApp
{
    class MonkeyAdapter : RecyclerView.Adapter
    {
        public event EventHandler<MonkeyAdapterClickEventArgs> ItemClick;
        public event EventHandler<MonkeyAdapterClickEventArgs> ItemLongClick;
        MonkeyViewModel viewModel;
        Activity activity;

        public MonkeyAdapter(MonkeyViewModel viewModel, Activity activity)
        {
            this.activity = activity;
            this.viewModel = viewModel;
            this.viewModel.Monkeys.CollectionChanged += Monkeys_CollectionChanged;
        }

        private void Monkeys_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            activity.RunOnUiThread(() =>
            {
                this.NotifyDataSetChanged();
            });
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.monkey_item;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new MonkeyAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var monkey = viewModel.Monkeys[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as MonkeyAdapterViewHolder;

            //TODO: bind up UI

            //holder.TextViewName.Text = monkey.Name;
            //holder.TextViewCity.Text = monkey.Location;
            //Glide.With(activity).Load(monkey.Image.OriginalString).Into(holder.ImageView);
        }

        public override int ItemCount => viewModel.Monkeys.Count;

        void OnClick(MonkeyAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(MonkeyAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class MonkeyAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextViewName { get; set; }
        public TextView TextViewCity { get; set; }
        public ImageView ImageView { get; set; }


        public MonkeyAdapterViewHolder(View itemView, Action<MonkeyAdapterClickEventArgs> clickListener,
                            Action<MonkeyAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            TextViewCity = itemView.FindViewById<TextView>(Resource.Id.city);
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.main_image);
            itemView.Click += (sender, e) => clickListener(new MonkeyAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new MonkeyAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class MonkeyAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}