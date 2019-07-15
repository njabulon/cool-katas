using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace src {
  public static class Utilities {
    public static IEnumerable<int> TreePreOrderTraversal (Node root) {
      if (root == null) return Enumerable.Empty<int> ();
      return new List<int> { root.Data }.Concat (TreePreOrderTraversal (root.Left)).Concat (TreePreOrderTraversal (root.Right));
    }

    public static IEnumerable<int> TreeInOrderTraversal (Node root) {
      if (root == null) return Enumerable.Empty<int> ();
      return TreeInOrderTraversal (root.Left).Concat (new List<int> { root.Data }).Concat (TreeInOrderTraversal (root.Right));
    }

    public static IEnumerable<int> TreePostOrderTraversal (Node root) {
      if (root == null) return Enumerable.Empty<int> ();
      return TreePostOrderTraversal (root.Left).Concat (TreePostOrderTraversal (root.Right)).Concat (new List<int> { root.Data });
    }
  }
}