using LanguageApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Classes
{
    public class DisplayObjectMaker
    {
        public DisplayObjectMaker()
        {

        }
        // Loops through all word pairs and gets the correct wordRecords in order to create a DisplayObject
        public List<DisplayObject> CreateDisplayObjects(List<WordPair> wordPairs, List<WordRecord> wordRecords)
        {
            List<DisplayObject> displayObjectList = new List<DisplayObject>();
            int index = 0;
            foreach (WordPair wp in wordPairs)
            {
                string original = wordRecords.Find(word => word.id == wp.original).word;
                string translation = wordRecords.Find(word => word.id == wp.translation).word;
                string description = wordRecords.Find(word => word.id == wp.original).description;
                displayObjectList.Add(new DisplayObject(index, original, translation, description));
                index++;
            }

            // JUST RETURN A COUPLE OF DISPLAY OBJECTS SO THIS WHOLE APP DOESNT CRASH AND BURN
            //List<DisplayObject> smallList = new List<DisplayObject>();
            //smallList.Add(displayObjectList[0]);
            //smallList.Add(displayObjectList[1]);
            //smallList.Add(displayObjectList[2]);
            //smallList.Add(displayObjectList[3]);
            //smallList.Add(displayObjectList[4]);
            //smallList.Add(displayObjectList[5]);
            //return smallList;
            
            return displayObjectList;
        }

    }
}
