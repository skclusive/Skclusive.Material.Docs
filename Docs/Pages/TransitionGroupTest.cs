using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Transition.Component;

namespace Skclusive.Material.Docs.Pages
{
    public partial class TransitionGroupTest : ComponentBase
    {
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
            TransitionState.Exited, new List<Tuple<string, object>>()
            {
                Tuple.Create<string, object>("opacity", 0)
            }
        }
    };

        protected string GetTransitionStyle(TransitionState state)
        {
            return CssUtil.ToStyle(DEFAULT_STYLES.Concat(TRANSITION_STYLES[state]), string.Empty);
        }

        public bool In { set; get; }

        protected int Count = 1;

        public List<ITransitionItem> Items { set; get; } = new List<ITransitionItem>();

        Task OnClick()
        {
            In = !In;

            Count++;

            Items = new List<ITransitionItem>()
            {
                new TransitionItemBuilder()
                .WithKey(Count)
                .WithName($"T{Count}")
                .WithTemplate(GetTransition())
                .Build()
            };

            Console.WriteLine($"Items.Count: {Items.Count}");

            StateHasChanged();

            return Task.CompletedTask;
        }

        private RenderFragment<ITransitionItemContext> GetTransition() => ((gcontext) =>
            (builder1) => {
                builder1.OpenRegion(gcontext.Key);
                builder1.OpenComponent<Skclusive.Transition.Component.Transition>(gcontext.Key + 1);
                builder1.AddAttribute(gcontext.Key + 2, "Name", gcontext.Name);
                builder1.AddAttribute(gcontext.Key + 3, "In", gcontext.In);
                builder1.AddAttribute(gcontext.Key + 4, "Timeout", 2000);
                //builder1.AddAttribute(5, "Appear", gcontext.Appear);
                //builder1.AddAttribute(6, "Enter", gcontext.Enter);
                //builder1.AddAttribute(7, "Exit",  gcontext.Exit);
                builder1.AddAttribute(gcontext.Key + 8, "OnExited", gcontext.OnExited);
                builder1.AddAttribute(gcontext.Key + 9, "ChildContent", (RenderFragment<ITransitionContext>)((tcontext) => (builder2) => {
                    builder2.OpenRegion(gcontext.Key);
                    builder2.OpenElement(gcontext.Key + 10, "div");
                    builder2.AddAttribute(gcontext.Key + 11, "style", GetTransitionStyle(tcontext.State));
                    builder2.AddMarkupContent(gcontext.Key + 12, "Name is: ");
                    builder2.AddContent(gcontext.Key + 13, gcontext.Name);
                    builder2.AddMarkupContent(gcontext.Key + 14, "State is: ");
                    builder2.AddContent(gcontext.Key + 15, tcontext.State);
                    builder2.AddElementReferenceCapture(gcontext.Key + 16, (__ref) =>
                    {
                        tcontext.RefBack.Current = __ref;
                    });
                    builder2.SetKey(gcontext.Name);
                    builder2.CloseElement();
                    builder2.CloseRegion();
                }));
                builder1.SetKey(gcontext.Name);
                builder1.CloseComponent();
                builder1.CloseRegion();
        });


        Action<IReference, bool> OnEnter => (IReference refback, bool appear) =>
        {
            Console.WriteLine("Sk-" + (appear ? "Appear" : "OnEnter"));
        };

        Action<IReference, bool> OnEntering => (IReference refback, bool appearing) =>
        {
            Console.WriteLine("Sk-" + (appearing ? "Appearing" : "OnEntering"));
        };

        Action<IReference, bool> OnEntered => (IReference refback, bool appeared) =>
        {
            Console.WriteLine("Sk-" + (appeared ? "Appeared" : "OnEntered"));
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