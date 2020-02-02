using System.Collections.Generic;
using GitExtUtils.GitUI.Theming;
using GitUI.Theming;
using ICSharpCode.TextEditor.Document;

namespace GitUI.Editor.Diff
{
    public class CombinedDiffHighlightService : DiffHighlightService
    {
        public static new CombinedDiffHighlightService Instance { get; } = new CombinedDiffHighlightService();

        protected CombinedDiffHighlightService()
        {
        }

        protected override int GetDiffContentOffset()
        {
            return 2;
        }

        protected override int TryHighlightAddedAndDeletedLines(IDocument document, int line, LineSegment lineSegment)
        {
            ProcessLineSegment(document, ref line, lineSegment, "++", AppColor.DiffAdded.Value());
            ProcessLineSegment(document, ref line, lineSegment, "+ ", AppColor.DiffAdded.Value());
            ProcessLineSegment(document, ref line, lineSegment, " +", AppColor.DiffAdded.Value());
            ProcessLineSegment(document, ref line, lineSegment, "--", AppColor.DiffRemoved.Value());
            ProcessLineSegment(document, ref line, lineSegment, "- ", AppColor.DiffRemoved.Value());
            ProcessLineSegment(document, ref line, lineSegment, " -", AppColor.DiffRemoved.Value());
            return line;
        }

        protected override List<ISegment> GetAddedLines(IDocument document, ref int line, ref bool found)
        {
            return LinePrefixHelper.GetLinesStartingWith(document, ref line, new[] { "+", " +" }, ref found);
        }

        protected override List<ISegment> GetRemovedLines(IDocument document, ref int line, ref bool found)
        {
            return LinePrefixHelper.GetLinesStartingWith(document, ref line, new[] { "-", " -" }, ref found);
        }
    }
}
