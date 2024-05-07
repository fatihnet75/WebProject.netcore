/*
@license
dhtmlxScheduler.Net v.3.3.0 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e.attachEvent("onTemplatesReady",function(){this.layers.sort(function(e,t){return e.zIndex-t.zIndex}),e._dp_init=function(t){t._methods=["_set_event_text_style","","changeEventId","deleteEvent"],this.attachEvent("onEventAdded",function(e){!this._loading&&this.validId(e)&&this.getEvent(e)&&this.getEvent(e).layer==t.layer&&t.setUpdated(e,!0,"inserted")}),this.attachEvent("onBeforeEventDelete",function(e){if(this.getEvent(e)&&this.getEvent(e).layer==t.layer){if(!this.validId(e))return;
var i=t.getState(e);return"inserted"==i||this._new_event?(t.setUpdated(e,!1),!0):"deleted"==i?!1:"true_deleted"==i?!0:(t.setUpdated(e,!0,"deleted"),!1)}return!0}),this.attachEvent("onEventChanged",function(e){!this._loading&&this.validId(e)&&this.getEvent(e)&&this.getEvent(e).layer==t.layer&&t.setUpdated(e,!0,"updated")}),t._getRowData=function(e){var t=this.obj.getEvent(e),i={};for(var a in t)0!==a.indexOf("_")&&(i[a]=t[a]&&t[a].getUTCFullYear?this.obj.templates.xml_format(t[a]):t[a]);return i},t._clearUpdateFlag=function(){},t.attachEvent("insertCallback",e._update_callback),t.attachEvent("updateCallback",e._update_callback),t.attachEvent("deleteCallback",function(e,t){this.obj.setUserData(t,this.action_param,"true_deleted"),this.obj.deleteEvent(t)
})},function(){var t=function(e){if(null===e||"object"!=typeof e)return e;var i=new e.constructor;for(var a in e)i[a]=t(e[a]);return i};e._dataprocessors=[],e._layers_zindex={};for(var i=0;i<e.layers.length;i++){if(e.config["lightbox_"+e.layers[i].name]={},e.config["lightbox_"+e.layers[i].name].sections=t(e.config.lightbox.sections),e._layers_zindex[e.layers[i].name]=e.config.inital_layer_zindex||5+3*i,e.layers[i].url){var a=new dataProcessor(e.layers[i].url);a.layer=e.layers[i].name,e._dataprocessors.push(a),e._dataprocessors[i].init(e)
}e.layers[i].isDefault&&(e.defaultLayer=e.layers[i].name)}}(),e.showLayer=function(e){this.toggleLayer(e,!0)},e.hideLayer=function(e){this.toggleLayer(e,!1)},e.toggleLayer=function(e,t){var i=this.getLayer(e);i.visible="undefined"!=typeof t?!!t:!i.visible,this.setCurrentView(this._date,this._mode)},e.getLayer=function(t){var i,a;"string"==typeof t&&(a=t),"object"==typeof t&&(a=t.layer);for(var n=0;n<e.layers.length;n++)e.layers[n].name==a&&(i=e.layers[n]);return i},e.attachEvent("onBeforeLightbox",function(t){var i=this.getEvent(t);
return this.config.lightbox.sections=this.config["lightbox_"+i.layer].sections,e.resetLightbox(),!0}),e.attachEvent("onClick",function(t){var i=e.getEvent(t);return!e.getLayer(i.layer).noMenu}),e.attachEvent("onEventCollision",function(t,i){var a=this.getLayer(t);if(!a.checkCollision)return!1;for(var n=0,s=0;s<i.length;s++)i[s].layer==a.name&&i[s].id!=t.id&&n++;return n>=e.config.collision_limit}),e.addEvent=function(t,i,a,n,s){var r=t;1!=arguments.length&&(r=s||{},r.start_date=t,r.end_date=i,r.text=a,r.id=n,r.layer=this.defaultLayer),r.id=r.id||e.uid(),r.text=r.text||"","string"==typeof r.start_date&&(r.start_date=this.templates.api_date(r.start_date)),"string"==typeof r.end_date&&(r.end_date=this.templates.api_date(r.end_date)),r._timed=this.isOneDayEvent(r);
var d=!this._events[r.id];this._events[r.id]=r,this.event_updated(r),this._loading||this.callEvent(d?"onEventAdded":"onEventChanged",[r.id,r])},this._evs_layer={};for(var t=0;t<this.layers.length;t++)this._evs_layer[this.layers[t].name]=[];e.addEventNow=function(t,i,a){var n={};"object"==typeof t&&(n=t,t=null);var s=6e4*(this.config.event_duration||this.config.time_step);t||(t=Math.round(e._currentDate().valueOf()/s)*s);var r=new Date(t);if(!i){var d=this.config.first_hour;d>r.getHours()&&(r.setHours(d),t=r.valueOf()),i=t+s
}n.start_date=n.start_date||r,n.end_date=n.end_date||new Date(i),n.text=n.text||this.locale.labels.new_event,n.id=this._drag_id=this.uid(),n.layer=this.defaultLayer,this._drag_mode="new-size",this._loading=!0,this.addEvent(n),this.callEvent("onEventCreated",[this._drag_id,a]),this._loading=!1,this._drag_event={},this._on_mouse_up(a)},e._t_render_view_data=function(e){if(this.config.multi_day&&!this._table_view){for(var t=[],i=[],a=0;a<e.length;a++)e[a]._timed?t.push(e[a]):i.push(e[a]);this._table_view=!0,this.render_data(i),this._table_view=!1,this.render_data(t)
}else this.render_data(e)},e.render_view_data=function(){if(this._not_render)return void(this._render_wait=!0);this._render_wait=!1,this.clear_view(),this._evs_layer={};for(var e=0;e<this.layers.length;e++)this._evs_layer[this.layers[e].name]=[];for(var t=this.get_visible_events(),e=0;e<t.length;e++)this._evs_layer[t[e].layer]&&this._evs_layer[t[e].layer].push(t[e]);if("month"==this._mode){for(var i=[],e=0;e<this.layers.length;e++)this.layers[e].visible&&(i=i.concat(this._evs_layer[this.layers[e].name]));
this._t_render_view_data(i)}else for(var e=0;e<this.layers.length;e++)if(this.layers[e].visible){var a=this._evs_layer[this.layers[e].name];this._t_render_view_data(a)}},e._render_v_bar=function(t,i,a,n,s,r,d,o,l){var _=t.id;-1==d.indexOf("<div class=")&&(d=e.templates["event_header_"+t.layer]?e.templates["event_header_"+t.layer](t.start_date,t.end_date,t):d),-1==o.indexOf("<div class=")&&(o=e.templates["event_text_"+t.layer]?e.templates["event_text_"+t.layer](t.start_date,t.end_date,t):o);var h=document.createElement("DIV"),c="dhx_cal_event",u=e.templates["event_class_"+t.layer]?e.templates["event_class_"+t.layer](t.start_date,t.end_date,t):e.templates.event_class(t.start_date,t.end_date,t);
u&&(c=c+" "+u);var v='<div event_id="'+_+'" class="'+c+'" style="position:absolute; top:'+a+"px; left:"+i+"px; width:"+(n-4)+"px; height:"+s+"px;"+(r||"")+'">';return v+='<div class="dhx_header" style=" width:'+(n-6)+'px;" >&nbsp;</div>',v+='<div class="dhx_title">'+d+"</div>",v+='<div class="dhx_body" style=" width:'+(n-(this._quirks?4:14))+"px; height:"+(s-(this._quirks?20:30))+'px;">'+o+"</div>",v+='<div class="dhx_footer" style=" width:'+(n-8)+"px;"+(l?" margin-top:-1px;":"")+'" ></div></div>',h.innerHTML=v,h.style.zIndex=100,h.firstChild
},e.render_event_bar=function(t){var i=this._els.dhx_cal_data[0],a=this._colsS[t._sday],n=this._colsS[t._eday];n==a&&(n=this._colsS[t._eday+1]);var s=this.xy.bar_height,r=this._colsS.heights[t._sweek]+(this._colsS.height?this.xy.month_scale_height+2:2)+t._sorder*s,d=document.createElement("DIV"),o=t._timed?"dhx_cal_event_clear":"dhx_cal_event_line",l=e.templates["event_class_"+t.layer]?e.templates["event_class_"+t.layer](t.start_date,t.end_date,t):e.templates.event_class(t.start_date,t.end_date,t);
l&&(o=o+" "+l);var _='<div event_id="'+t.id+'" class="'+o+'" style="position:absolute; top:'+r+"px; left:"+a+"px; width:"+(n-a-15)+"px;"+(t._text_style||"")+'">';t._timed&&(_+=e.templates["event_bar_date_"+t.layer]?e.templates["event_bar_date_"+t.layer](t.start_date,t.end_date,t):e.templates.event_bar_date(t.start_date,t.end_date,t)),_+=e.templates["event_bar_text_"+t.layer]?e.templates["event_bar_text_"+t.layer](t.start_date,t.end_date,t):e.templates.event_bar_text(t.start_date,t.end_date,t)+"</div>)",_+="</div>",d.innerHTML=_,this._rendered.push(d.firstChild),i.appendChild(d.firstChild)
},e.render_event=function(t){var i=e.xy.menu_width;if(e.getLayer(t.layer).noMenu&&(i=0),!(t._sday<0)){var a=e.locate_holder(t._sday);if(a){var n=60*t.start_date.getHours()+t.start_date.getMinutes(),s=60*t.end_date.getHours()+t.end_date.getMinutes()||60*e.config.last_hour,r=Math.round((60*n*1e3-60*this.config.first_hour*60*1e3)*this.config.hour_size_px/36e5)%(24*this.config.hour_size_px)+1,d=Math.max(e.xy.min_event_height,(s-n)*this.config.hour_size_px/60)+1,o=Math.floor((a.clientWidth-i)/t._count),l=t._sorder*o+1;
t._inner||(o*=t._count-t._sorder);var _=this._render_v_bar(t.id,i+l,r,o,d,t._text_style,e.templates.event_header(t.start_date,t.end_date,t),e.templates.event_text(t.start_date,t.end_date,t));if(this._rendered.push(_),a.appendChild(_),l=l+parseInt(a.style.left,10)+i,r+=this._dy_shift,_.style.zIndex=this._layers_zindex[t.layer],this._edit_id==t.id){_.style.zIndex=parseInt(_.style.zIndex)+1;var h=_.style.zIndex;o=Math.max(o-4,e.xy.editor_width);var _=document.createElement("DIV");_.setAttribute("event_id",t.id),this.set_xy(_,o,d-20,l,r+14),_.className="dhx_cal_editor",_.style.zIndex=h;
var c=document.createElement("DIV");this.set_xy(c,o-6,d-26),c.style.cssText+=";margin:2px 2px 2px 2px;overflow:hidden;",c.style.zIndex=h,_.appendChild(c),this._els.dhx_cal_data[0].appendChild(_),this._rendered.push(_),c.innerHTML="<textarea class='dhx_cal_editor'>"+t.text+"</textarea>",this._quirks7&&(c.firstChild.style.height=d-12+"px"),this._editor=c.firstChild,this._editor.onkeypress=function(t){if((t||event).shiftKey)return!0;var i=(t||event).keyCode;i==e.keys.edit_save&&e.editStop(!0),i==e.keys.edit_cancel&&e.editStop(!1)
},this._editor.onselectstart=function(e){return(e||event).cancelBubble=!0,!0},c.firstChild.focus(),this._els.dhx_cal_data[0].scrollLeft=0,c.firstChild.select()}if(this._select_id==t.id){_.style.zIndex=parseInt(_.style.zIndex)+1;for(var u=this.config["icons_"+(this._edit_id==t.id?"edit":"select")],v="",g=0;g<u.length;g++)v+="<div class='dhx_menu_icon "+u[g]+"' title='"+this.locale.labels[u[g]]+"'></div>";var f=this._render_v_bar(t.id,l-i+1,r,i,20*u.length+26,"","<div class='dhx_menu_head'></div>",v,!0);
f.style.left=l-i+1,f.style.zIndex=_.style.zIndex,this._els.dhx_cal_data[0].appendChild(f),this._rendered.push(f)}}}},e.filter_agenda=function(t,i){var a=e.getLayer(i.layer);return a&&a.visible}})});