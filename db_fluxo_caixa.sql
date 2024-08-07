select Subcategoria.IdCategoria, Subcategoria.DscTipoSubcategoria, Categoria.DscTipoCategoria
from Subcategoria
inner join Categoria on Subcategoria.IdCategoria = Categoria.IdCategoria
order by Categoria.DscTipoCategoria