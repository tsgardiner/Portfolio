using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class CardCarouselScreenCS : CarouselPage
    {
        private List<DisplayObject> displayObjects;
        
        private int previous;
        private int current;
        private int next;

        ContentPage C; // USED FOR DEBUGING

        private bool load;

        public CardCarouselScreenCS(List<DisplayObject> displayObjects)
        {
            previous = -1;
            current = 0;
            next = 1;

            load = false;
            C = CurrentPage;

            this.displayObjects = displayObjects;            
            
            // Add first 2 items
            this.Children.Add(new WordPageCS(displayObjects[0]));
            this.Children.Add(new WordPageCS(displayObjects[1]));

            load = true;
        }
        // When ever a swipe occurs
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            C = CurrentPage; // TESTING
            if (load)
            {                
                if (CurrentPage.Equals(Children[Children.Count - 1]))
                {
                    SwipeLeft();
                }
                else
                {
                    SwipeRight();
                }
                GC.Collect();
            }            
        }

        public void SwipeLeft()
        {
            previous += 1;
            current += 1;
            next += 1;
            if (current != displayObjects.Count - 1)//(next <= displayObjects.Count - 1)
            {
                Children.Add((new WordPageCS(displayObjects[next])));                
            }
            if (previous > 0)
            {
                Children.RemoveAt(0);
            }
        }

        public void SwipeRight()
        {
            previous -= 1;
            current -= 1;
            next -= 1;
            if (current != 0)//(previous > 0)
            {
                //Children.Add(new WordPageCS(displayObjects[previous]));   // NOT ADDING TO START . ADDING TO END     
                //CurrentPage = Children[1]; // Do I need to move CurrentPage before inserting at 0  ?  Would cause event to fire again. use flag.
                Children.Insert(0, new WordPageCS(displayObjects[previous]));
            }
            if (next < displayObjects.Count - 1)
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        //protected override void OnChildRemoved()
        //{
        //    base.OnChildRemoved();
        //}



    }
}
