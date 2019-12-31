using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Transition.Component;

namespace Skclusive.Material.Docs.Pages
{
    public partial class TransitionTest : ComponentBase
    {
        protected string KeyT3 = "t3";

        private readonly static int DURATION = 2000;

        private readonly static IEnumerable<Tuple<string, object>> DEFAULT_STYLES = new List<Tuple<string, object>>()
        {
            Tuple.Create<string, object>("opacity", 0),
            Tuple.Create<string, object>("color", "#ffffff"),
            Tuple.Create<string, object>("transition", $"opacity {DURATION}ms ease-in-out")
        };

        private readonly static IDictionary<TransitionState, IEnumerable<Tuple<string, object>>> TRANSITION_STYLES = new Dictionary<TransitionState, IEnumerable<Tuple<string, object>>>()
        {
            {
                TransitionState.Entering, new List<Tuple<string, object>>()
                {
                    Tuple.Create<string, object>("opacity", 1),
                    Tuple.Create<string, object>("background-color", "green")
                }
            },
            {
                TransitionState.Entered, new List<Tuple<string, object>>()
                {
                    Tuple.Create<string, object>("opacity", 1),
                    Tuple.Create<string, object>("background-color", "blue")
                }
            },
            {
                TransitionState.Exiting, new List<Tuple<string, object>>()
                {
                    Tuple.Create<string, object>("opacity", 0),
                    Tuple.Create<string, object>("background-color", "red")
                }
            },
            {
                TransitionState.Exited, new List<Tuple<string, object>
                    >()
                {
                    Tuple.Create<string, object>("opacity", 0)
                }
            }
        };

        protected string GetTransitionStyle(TransitionState state)
        {
            return CssUtil.ToStyle(DEFAULT_STYLES.Concat(TRANSITION_STYLES[state]),
            string.Empty);
        }

        public bool In { set; get; }

        public bool CssInProp { set; get; }

        Task ToggleCssInProp()
        {
            CssInProp = !CssInProp;

            return Task.CompletedTask;
        }

        Task OnClick()
        {
            In = !In;

            return Task.CompletedTask;
        }

        Action<IReference, bool> OnEnter => (IReference refback, bool appear) =>
        {
            Console.WriteLine("Sk-" + (appear ? "Appear" : "Enter"));
        };

        Action<IReference, bool> OnEntering => (IReference refback, bool appearing) =>
        {
            Console.WriteLine("Sk-" + (appearing ? "appearing" : "entering"));
        };

        Action<IReference, bool> OnEntered => (IReference refback, bool appeared) =>
        {
            Console.WriteLine("Sk-" + appeared);
        };

        Action<IReference> OnExit => (IReference refback) =>
        {
            Console.WriteLine("Sk-OnExit");
        };

        Action<IReference> OnExiting => (IReference refback) =>
        {
            Console.WriteLine("Sk-OnExiting");
        };

        Action<IReference> OnExited => (IReference refback) =>
        {
            Console.WriteLine("Sk-OnExited");
        };
    }
}