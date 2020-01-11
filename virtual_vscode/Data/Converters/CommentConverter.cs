using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Model;
using System.Linq;
using System;

namespace LojaVirtual.Data.Converters
{
    public class CommentConverter : IParser<CommentVO, Comment>, IParser<Comment, CommentVO>
    {
        public Comment Parse(CommentVO origin)
        {
            if (origin == null) return new Comment();
            return new Comment
            {
                Id = origin.Id,
                User = origin.User,
                DtReg = origin.DtReg,
                Texto = origin.Texto
            };
        }

        public CommentVO Parse(Comment origin)
        {
            if (origin == null) return new CommentVO();

            return new CommentVO
            {   Id = origin.Id,
                User = origin.User,
                DtReg = origin.DtReg,
                Texto = origin.Texto

            };
        }

        public List<Comment> ParseList(List<CommentVO> origin)
        {
            if (origin == null) return new List<Comment>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CommentVO> ParseList(List<Comment> origin)
        {
            if (origin == null) return new List<CommentVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
