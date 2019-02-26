using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class DialogueData
    {
        public DialogueEntry German { get; set; }
        public DialogueEntry Taiwanese { get; set; }
        public DialogueData(DialogueEntry german,DialogueEntry taiwanese)
        {
        	German = german;
        	Taiwanese = taiwanese;
        }
    }
}