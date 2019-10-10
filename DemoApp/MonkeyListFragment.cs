

using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DemoApp.Shared;

namespace DemoApp
{
    public class MonkeyListFragment : Fragment
    {
        MainActivity activity;
        MonkeyViewModel viewModel = new MonkeyViewModel();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            activity.toolbar.Title = "Monkey Finder";
            View view = inflater.Inflate(Resource.Layout.fragment_monkeys, container, false);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            var refreshButton = view.FindViewById<Button>(Resource.Id.button_refresh);

            //TODO: add click handler           

            var adapter = new MonkeyAdapter(viewModel, activity);
            recyclerView.SetAdapter(adapter);
            var layoutManager = new LinearLayoutManager(Context);
            recyclerView.SetLayoutManager(layoutManager);
            return view;
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            activity = context as MainActivity;
        }

    }
}